using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TharawatGateway.Domain.Constant;
using TharawatGateway.Domain.Entities;

namespace TharawatGateway.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TharawatGatewayDB;Trusted_Connection=True;MultipleActiveResultSets=true;trustservercertificate=True;");

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseModel>().Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.ModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedDate = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Product> products { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<Currency> currencies { get; set; }
        // public DbSet<GatewayService> gatewayServices { get; set; }
        public DbSet<Governorate> governorates { get; set; }
        public DbSet<Hobby> hobbies { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Category> categories { get; set; }
        // public DbSet<GatewayProvider> gatewayProviders { get; set; }
        public DbSet<Purpose> purposes { get; set; }
    }
}