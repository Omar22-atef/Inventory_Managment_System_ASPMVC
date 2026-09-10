using Microsoft.EntityFrameworkCore;

namespace Inventory_Managment_System_ASPMVC.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
