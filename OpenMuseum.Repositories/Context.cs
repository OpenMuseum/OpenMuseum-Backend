using OpenMuseum.Backend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OpenMuseum.Models;

namespace OpenMuseum.Repositories
{
    public class OpenMuseumContext : DbContext
    {
        public DbSet<BaseLayer> BaseLayers { get; set; }
        public DbSet<DataLayer> DataLayers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Point> Points { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}