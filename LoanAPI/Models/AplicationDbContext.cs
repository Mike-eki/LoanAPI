using LoanAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace LoanAPI.Models
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) :base(options)
        {

        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Thing> Things { get; set; }
    }
}
