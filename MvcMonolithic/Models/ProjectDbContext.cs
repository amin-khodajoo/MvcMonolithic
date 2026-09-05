using Microsoft.EntityFrameworkCore;
using MvcMonolithic.Models.DomainModels.PersonAggregate;
using MvcMonolithic.Models.DomainModels.ProductAggregate;

namespace MvcMonolithic.Models
{
    public class ProjectDbContext : DbContext
    {
        // Add Connection String

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MvcMonolithic;Integrated Security=True;Persist Security Info=False;Trust Server Certificate=True;");
            }
        }

        public DbSet<Person> Person {  get; set; }
        public DbSet<Product> Product { get; set; }

    }
}
