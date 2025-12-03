using BabiesStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BabiesStoreApi.Data
{
    public class StoreContextDB:DbContext
    {
        public StoreContextDB(DbContextOptions<StoreContextDB> options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderProduct> OrderProducts { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>()
        //        .HasMany(c => c.SubCategories)
        //        .WithOne(c => c.ParentCategory)
        //        .HasForeignKey(c => c.ParentCategoryId)
        //        .OnDelete(DeleteBehavior.Restrict); // כדי למנוע מחיקה של כל העץ בטעות
        //}



    }
}
