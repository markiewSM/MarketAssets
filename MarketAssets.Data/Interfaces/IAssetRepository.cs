using MarketAssets.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketAssets.Data.Interfaces
{
    public interface IAssetRepository
    {
        List<AssetsList> GetAllAssetLists();
        List<AssetsList> GetAssetsByProperyAndValue(string property, bool value);
        List<AssetsProperties> GetAssetsProperties();
        void UpdateAssetFromFile(List<AssetsList> asset);
        void UpdateAsset(long id, string property, string value, string timestamp);
        List<AssetsList> ImportValuesFromFile(string filePath);
    }
}
