﻿using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using System.Configuration;
using Microsoft.Data.Entity.AzureTableStorage.Metadata;

namespace CycleSales.WarrantyModel
{
    public class WarrantyContext : DbContext
    {
        public DbSet<WarrantyInfo> Warranties { get; set; }

        protected override void OnConfiguring(DbContextOptions options)
        {
            options.UseAzureTableStorage(ConfigurationManager.ConnectionStrings["WarrantyConnection"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WarrantyInfo>()
                .ForAzureTableStorage()
                .PartitionAndRowKey(w => w.BikeModelNo, w => w.BikeSerialNo);
        }
    }
}
