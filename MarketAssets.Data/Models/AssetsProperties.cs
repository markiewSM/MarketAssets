using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarketAssets.Data.Models
{
    public class AssetsProperties
    {
        [Key]
        public short Id { get; set; }
        public short AssetPropertyId {get;set;}
        public string Name { get; set; }
    }
}
