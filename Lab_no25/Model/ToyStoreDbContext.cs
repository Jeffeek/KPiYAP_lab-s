using Lab_no25.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab_no25.Model
{
    public class ToyStoreDbContext : DbContext
    {
        public ToyStoreDbContext(DbContextOptions<ToyStoreDbContext> options) : base(options) { }

        public DbSet<SaleEntity> Sales { get; set; }

        public DbSet<ToyEntity> Toys { get; set; }

        public DbSet<ToyCategoryEntity> ToyCategories { get; set; }
    }
}