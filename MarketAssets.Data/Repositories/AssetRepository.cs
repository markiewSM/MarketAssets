using MarketAssets.Data.ImportFileHelper;
using MarketAssets.Data.Interfaces;
using MarketAssets.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketAssets.Data.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private List<Asset> assets = new List<Asset>();
        private List<AssetsList> assetLists = new List<AssetsList>();
        private List<AssetsProperties> assetPriop = new List<AssetsProperties>();
        private ImportsAssetFromFile importAsset = new ImportsAssetFromFile();

        public void UpdateAssetFromFile(List<AssetsList> asset)
        {
            throw new NotImplementedException();
        }

        public List<AssetsList> GetAllAssetLists()
        {
            throw new NotImplementedException();
        }

        public List<Asset> GetAllAssets()
        {
            throw new NotImplementedException();
        }

        public List<Asset> GetAsset(bool value)
        {
            throw new NotImplementedException();
        }

        public List<AssetsList> GetAssetsByProperyAndValue(string property, bool value)
        {
            throw new NotImplementedException();
            //return assetLists.Where(f => f.Property == property && f.Value == value).ToList();
        }
        public List<AssetsProperties> GetAssetsProperties()
        {
            throw new NotImplementedException();
        }

        public List<AssetsList> ImportValuesFromFile(string filePath)
        {
            return importAsset.ImportValuesFromFile(filePath);
        }

        public void UpdateAsset(long id, string property, string value, string timestamp)
        {
            throw new NotImplementedException();
        }
    }
}
