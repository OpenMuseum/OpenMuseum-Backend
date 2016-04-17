using OpenMuseum.Backend.Models;
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
        public DbSet<Region> Regions { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Page> Pages { get; set; }
        
        public OpenMuseumContext() : base("OpenMuseumContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.ValidateOnSaveEnabled = false;
            Configuration.UseDatabaseNullSemantics = true;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Page>()
                .HasOptional(o => o.Region)
                .WithOptionalPrincipal()
                .Map(o => o.MapKey("PageId"));

            modelBuilder.Entity<Page>()
                .HasOptional(o => o.Point)
                .WithOptionalPrincipal()
                .Map(o => o.MapKey("PageId"));

            modelBuilder.Entity<Point>()
                .HasOptional(x => x.Region)
                .WithMany(x => x.Points)
                .HasForeignKey(x => x.RegionId);

            modelBuilder.Entity<DataLayer>()
                .HasRequired(x => x.BaseLayer)
                .WithMany( x => x.DataLayers)
                .HasForeignKey( x => x.BaseLayerId);

            modelBuilder.Entity<DataLayer>()
                .HasOptional(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey( x => x.ParentId);

            modelBuilder.Entity<Region>()
                .HasRequired(x => x.BaseLayer)
                .WithMany(x => x.Regions)
                .HasForeignKey( x=> x.BaseLayerId); 

            modelBuilder.Entity<Page>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Pages)
                .Map(x =>
                {
                    x.ToTable("PageTags");
                    x.MapLeftKey("PageId");
                    x.MapRightKey("TagId");
                });

            modelBuilder.Entity<Point>()
                .HasMany(x => x.DataLayers)
                .WithMany(x => x.Points)
                .Map(x =>
                {
                    x.ToTable("DataLayerPoints");
                    x.MapLeftKey("DataLayerId");
                    x.MapRightKey("PointId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}