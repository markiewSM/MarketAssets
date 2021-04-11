using MarketAssets.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MarketAssets.Data.ImportFileHelper
{
    class AssetsValues
    {
        public int AssetId;
        public string Properties;
        public bool Value;
        public DateTime TimeStamp;
        public static AssetsValues valuesFromFile(string fileLine)
        {
            bool _value;
            string dateStr = "";

            char[] trimValues = { '\"', '\'', '"', ' ' };
            string[] values = fileLine.Split(',');

            AssetsValues assets = new AssetsValues();

            assets.AssetId = Convert.ToInt32(values[0]);
            assets.Properties = Convert.ToString(values[1].Trim(trimValues));
            assets.Value = bool.TryParse(values[2].Trim(trimValues), out _value);

            dateStr = values[3].Trim(trimValues);
            assets.TimeStamp = dateStr != "" ? Convert.ToDateTime(dateStr) : DateTime.MinValue;

            return assets;
        }
    }

    class ItemEqualityComparer : IEqualityComparer<AssetsValues>
    {
        public bool Equals(AssetsValues x, AssetsValues y)
        {
            // Two items are equal if their keys are equal.
            return x.AssetId == y.AssetId;
        }

        public int GetHashCode(AssetsValues obj)
        {
            return obj.AssetId.GetHashCode();
        }
    }
    public class ImportsAssetFromFile
    {
        public List<AssetsList> ImportValuesFromFile(string filePath)
        {
            try
            {

                List<AssetsValues> values = File.ReadAllLines(filePath).Select(v => AssetsValues.valuesFromFile(v)).OrderBy(f => f.TimeStamp).ToList();
                var result = values.Distinct(new ItemEqualityComparer());

                List<AssetsList> lst = (from r in result
                                        select new AssetsList
                                        {
                                            AssetId = r.AssetId,
                                            Property = r.Properties,
                                            TimeStamp = r.TimeStamp,
                                            Value = r.Value
                                        }).ToList();

                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
    }
}
