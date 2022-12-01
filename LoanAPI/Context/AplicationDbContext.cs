using Microsoft.EntityFrameworkCore;
using LoanAPI.Context.Entities;

namespace LoanAPI.Context
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
