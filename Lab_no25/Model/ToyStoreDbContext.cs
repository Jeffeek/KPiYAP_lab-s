using Lab_no25.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab_no25.Model
{
    public class ToyStoreDbContext : DbContext
    {
        #region Overrides of DbContext

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        #endregion

        public DbSet<SaleEntity> Sales { get; set; }

        public DbSet<ToyEntity> Toys { get; set; }

        public DbSet<ToyCategoryEntity> ToyCategories { get; set; }
    }
}