using Showroom.Domain.Entities.Register;
using Microsoft.EntityFrameworkCore;

namespace Showroom.Persistence.Data
{
    public class ShowroomDataContext : DbContext
    {

        public ShowroomDataContext(DbContextOptions<ShowroomDataContext> options) : base(options)
        {

        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryEntity>(e =>
            {
                e.ToTable("tb_Categories");
                e.HasKey(x => x.Id);
                e.HasMany(x => x.Products)
                    .WithOne()
                    .HasForeignKey(p => p.IdCategory)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ProductEntity>(e =>
            {
                e.ToTable("tb_Products");
                e.HasKey(x => x.Id);
            });
        }
    }
}