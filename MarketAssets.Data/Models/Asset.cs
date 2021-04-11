using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketAssets.Data.Models
{
    public class Asset
    {

        [Key]
        public long Id { get; set; }
        public long AssetId { get; set; }
        public bool Value { get; set; }
        public DateTime? Timestamp { get; set; }

        [ForeignKey("AssetProperty")]
        public short? AssetPropertyId { get; set; }
        public virtual AssetsProperties AssetProperty { get;set;}
    }
}

