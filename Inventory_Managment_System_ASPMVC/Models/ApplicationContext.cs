using System.Reflection.Metadata.Ecma335;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasQueryFilter(c => !c.IsDeleted);

            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }

    }
}
