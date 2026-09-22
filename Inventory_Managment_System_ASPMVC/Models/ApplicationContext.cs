using Microsoft.EntityFrameworkCore;

namespace Inventory_Managment_System_ASPMVC.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductSuppliers> ProductSuppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasQueryFilter(c => !c.IsDeleted);

            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<ProductSuppliers>()
                .HasKey(p => new { p.ProductId, p.SupplierId});

            modelBuilder.Entity<Supplier>()
                .HasQueryFilter(s => !s.IsDeleted);
            base.OnModelCreating(modelBuilder);
        }

    }
}
