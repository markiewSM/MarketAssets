using System;
using System.Collections.Generic;
using System.Text;

namespace MarketAssets.Data.Models
{
    public class AssetsList
    {
       public long AssetId { get; set; }
        public string Property { get; set; }
        public bool Value { get; set; }
        public DateTime? TimeStamp { get; set; }

    }
}
