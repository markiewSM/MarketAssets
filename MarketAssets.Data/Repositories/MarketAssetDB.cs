using MarketAssets.Data.Interfaces;
using MarketAssets.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MarketAssets.Data.Repositories
{
    public class MarketAssetDB : IAssetRepository
    {
        private MarketAssetContext db; 
        private AssetRepository importAsset = new AssetRepository();
        private readonly ILogger<MarketAssetDB> _logger;
       
        public MarketAssetDB(MarketAssetContext _db, ILogger<MarketAssetDB> logger)
        {
            this.db = _db;
            _logger = logger;
        }

        public void UpdateAssetFromFile(List<AssetsList> asset)
        {
            foreach(AssetsList astLst in asset)
            {
                Asset ast = db.Assets.Where(x => x.Id == astLst.AssetId && x.Timestamp < astLst.TimeStamp).FirstOrDefault();
                if(ast == null )
                {
                    _logger.LogError("AssetId :{0} , Value:{1},TimeStamp{2}, does not exists in db", astLst.AssetId, astLst.Value, astLst.TimeStamp);
                   
                    if (Debugger.IsAttached)
                        Debug.WriteLine("AssetId :{0} , Value:{1},TimeStamp{2}, does not exists in db", astLst.AssetId, astLst.Value, astLst.TimeStamp);
                }
                else
                {
                    ast.Value = astLst.Value;
                    ast.Timestamp = astLst.TimeStamp;
                    db.SaveChanges();
                }
            }
           
        }

        public List<AssetsList> GetAllAssetLists()
        {
            return (from s in db.Assets
                    select new AssetsList
                    {
                        AssetId = s.AssetId,
                        Property = s.AssetProperty.Name,
                        Value = s.Value,
                        TimeStamp = s.Timestamp
                    }).ToList();
        }

        public List<Asset> GetAllAssets()
        {
            return db.Assets.Include(x => x.AssetProperty).ToList();
        }

        public List<Asset> GetAsset(bool value)
        {
            return db.Assets.Where(x => x.Value == value).ToList();
        }

        public List<AssetsList> GetAssetsByProperyAndValue(string property, bool value)
        {
            return (from s in db.Assets
                    where s.Value == value
                    && s.AssetProperty.Name == property
                   select new AssetsList
                   {
                       AssetId = s.AssetId,
                       Property = s.AssetProperty.Name,
                       Value = s.Value,
                       TimeStamp = s.Timestamp
                   }).ToList();
        }

        public List<AssetsProperties> GetAssetsProperties()
        {
            throw new NotImplementedException();
        }

        public List<AssetsList> ImportValuesFromFile(string filePath)
        {
            List<AssetsList> astLst = importAsset.ImportValuesFromFile(filePath);
            
            if (astLst != null)
                UpdateAssetFromFile(astLst);

            return astLst;
        }

        public void UpdateAsset(long id, string property, string value, string timestamp)
        {
            Asset ast = db.Assets.Include(x=> x.AssetProperty).Where(x => x.Id == id && x.AssetProperty.Name == property).FirstOrDefault();
            if (ast == null)
            {
                _logger.LogError("AssetId :{0} , Value:{1},TimeStamp{2},Property{3}, does not exists in db", id, value, timestamp,property);
                
                if (Debugger.IsAttached)
                    Debug.WriteLine("AssetId :{0} , Value:{1},TimeStamp{2}, Property{3}, does not exists in db", id, value, timestamp, property);
            }
            else
            {
                DateTime _timeStamp;
                bool _value;
                
                bool.TryParse(value, out _value);
                DateTime.TryParse(timestamp,out _timeStamp) ;
                
                if (ast.Timestamp < _timeStamp)
                {
                    ast.Value = _value;
                    ast.Timestamp = _timeStamp;
                    db.SaveChanges();
                }
            }
        }
    }
}
