using Microsoft.EntityFrameworkCore;

namespace Resources.Data
{
    public class ResourceDbContext : DbContext
    {
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<ResourceUsage> ResourceUsages { get; set; }

        public ResourceDbContext()
        {
            if (this.Database != null)
            {
                this.Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\ResourceDb.mdf; Integrated Security=True; MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResourceUsage>(entity =>
            {
                entity.HasOne(usage => usage.Resource).
                    WithMany(resource => resource.ResourceUsages).
                    HasForeignKey(usage => usage.ResourceName).
                    OnDelete(DeleteBehavior.ClientSetNull);
            });

            Resource r1 = new Resource() { UniqueName = "Resource1", MaximumUsages = 2 };
            Resource r2 = new Resource() { UniqueName = "Resource2", MaximumUsages = 3 };
            Resource r3 = new Resource() { UniqueName = "Resource3", MaximumUsages = 4 };

            /*
            ResourceUsage u1 = new ResourceUsage() { Id = 1, ResourceName = r1.UniqueName };
            ResourceUsage u2 = new ResourceUsage() { Id = 2, ResourceName = r1.UniqueName };
            ResourceUsage u3 = new ResourceUsage() { Id = 3, ResourceName = r2.UniqueName };
            ResourceUsage u4 = new ResourceUsage() { Id = 4, ResourceName = r2.UniqueName };
            ResourceUsage u5 = new ResourceUsage() { Id = 5, ResourceName = r3.UniqueName };
            ResourceUsage u6 = new ResourceUsage() { Id = 6, ResourceName = r3.UniqueName };
            */
            modelBuilder.Entity<Resource>().HasData(r1, r2, r3);
            //modelBuilder.Entity<ResourceUsage>().HasData(u1, u2, u3, u4, u5, u6);
        }
    }
}
