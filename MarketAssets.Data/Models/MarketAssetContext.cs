using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketAssets.Data.Models
{
    public class MarketAssetContext : DbContext
    {
        public MarketAssetContext(DbContextOptions<MarketAssetContext> options) : base(options)
        {

        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetsProperties> AssetProperty { get; set; }
        
        protected override void OnModelCreating(ModelBuilder bldr)
        {
            base.OnModelCreating(bldr);
            
            bldr.Entity<AssetsProperties>(t =>
            {
                t.HasData(new AssetsProperties
                {
                    Id = 1,
                    AssetPropertyId = 1,
                    Name = "is fix income"

                });
            });

            bldr.Entity<Asset>(t =>
            {
                t.HasData(new Asset
                {
                    Id = 1,
                    AssetId = 1,
                    AssetPropertyId = 1,
                    Value = false,
                    Timestamp = DateTime.Now.AddDays(-2)

                });
            });

            bldr.Entity<AssetsProperties>(t =>
            {
                t.HasData(new AssetsProperties
                {
                    Id = 2,
                    AssetPropertyId = 2,
                    Name = "is convertible"

                });
            });
            
            bldr.Entity<Asset>(t =>
            {
                t.HasData(new Asset
                {
                    Id = 2,
                    AssetId = 2,
                    AssetPropertyId = 2,
                    Value = true,
                    Timestamp = DateTime.Now.AddDays(-2)

                });
            });

            bldr.Entity<AssetsProperties>(t =>
            {
                t.HasData(new AssetsProperties
                {
                    Id = 3,
                    AssetPropertyId = 3,
                    Name = "is swap"

                });
            });

            bldr.Entity<Asset>(t =>
            {
                t.HasData(new Asset
                {
                    Id = 3,
                    AssetId = 3,
                    AssetPropertyId = 3,
                    Value = true,
                    Timestamp = DateTime.Now.AddDays(-2)

                });
            });

            bldr.Entity<AssetsProperties>(t =>
            {
                t.HasData(new AssetsProperties
                {
                    Id = 4,
                    AssetPropertyId = 4,
                    Name = "is cash"

                });
            });

            bldr.Entity<Asset>(t =>
            {
                t.HasData(new Asset
                {
                    Id = 4,
                    AssetId = 4,
                    AssetPropertyId = 4,
                    Value = true,
                    Timestamp = DateTime.Now.AddDays(-2)

                });
            });

            bldr.Entity<AssetsProperties>(t =>
            {
                t.HasData(new AssetsProperties
                {
                    Id = 5,
                    AssetPropertyId = 5,
                    Name = "is future"

                });
            });

            bldr.Entity<Asset>(t =>
            {
                t.HasData(new Asset
                {
                    Id = 5,
                    AssetId = 5,
                    AssetPropertyId = 5,
                    Value = true,
                    Timestamp = DateTime.Now.AddDays(-2)

                });
            });

            bldr.Entity<Asset>(t =>
            {
                t.HasData(new Asset
                {
                    Id = 6,
                    AssetId = 6,
                    AssetPropertyId = 1,
                    Value = false,
                    Timestamp = DateTime.Now.AddDays(-2)

                });
            });

            bldr.Entity<Asset>(t =>
            {
                t.HasData(new Asset
                {
                    Id = 7,
                    AssetId = 7,
                    AssetPropertyId = 2,
                    Value = false,
                    Timestamp = DateTime.Now.AddDays(-2)

                });
            });

            bldr.Entity<Asset>(t =>
            {
                t.HasData(new Asset
                {
                    Id = 8,
                    AssetId = 8,
                    AssetPropertyId = 2,
                    Value = false,
                    Timestamp = DateTime.Now.AddDays(-2)

                });
            });


            bldr.Entity<Asset>(t =>
            {
                t.HasData(new Asset
                {
                    Id = 9,
                    AssetId = 9,
                    AssetPropertyId = 3,
                    Value = false,
                    Timestamp = DateTime.Now.AddDays(-2)

                });
            });

            bldr.Entity<Asset>(t =>
            {
                t.HasData(new Asset
                {
                    Id = 10,
                    AssetId = 10,
                    AssetPropertyId = 4,
                    Value = false,
                    Timestamp = DateTime.Now.AddDays(-2)

                });
            });

            bldr.Entity<Asset>(t =>
            {
                t.HasData(new Asset
                {
                    Id = 11,
                    AssetId = 11,
                    AssetPropertyId = 5,
                    Value = false,
                    Timestamp = DateTime.Now.AddDays(-2)

                });
            });
        }
    }
}
