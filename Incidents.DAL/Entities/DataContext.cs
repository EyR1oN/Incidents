using Microsoft.EntityFrameworkCore;

namespace Incidents.DAL.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        { 
        }
        public DbSet<Account> Account { get; set; }
        public DbSet<Incident> Incident { get; set; }
        public DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    Id = 1,
                    Name = "Incident 1",
                    Description = "Incident Description 1",
                },
                new Incident
                {
                    Id = 2,
                    Name = "Incident 2",
                    Description = "Incident Description 2",
                }
            );

            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    Name = "Account 1",
                    IncidentId = 1
                },
                new Account
                {
                    Id = 2,
                    Name = "Account 2",
                    IncidentId = 1
                },
                new Account
                {
                    Id = 3,
                    Name = "Account 3",
                    IncidentId = 2
                }
            );

            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    FirstName = "FirstName 1",
                    LastName = "LastName 1",
                    Email = "Contact1@gmail.com",
                    AccountId = 1
                },
                new Contact
                {
                    Id = 2,
                    FirstName = "FirstName 2",
                    LastName = "LastName 2",
                    Email = "Contact2@gmail.com",
                    AccountId = 1
                },
                new Contact
                {
                    Id = 3,
                    FirstName = "FirstName 3",
                    LastName = "LastName 3",
                    Email = "Contact3@gmail.com",
                    AccountId = 1
                },
                new Contact
                {
                    Id = 4,
                    FirstName = "FirstName 4",
                    LastName = "LastName 4",
                    Email = "Contact4@gmail.com",
                    AccountId = 2
                },
                new Contact
                {
                    Id = 5,
                    FirstName = "FirstName 5",
                    LastName = "LastName 5",
                    Email = "Contact5@gmail.com",
                    AccountId = 2
                },
                new Contact
                {
                    Id = 6,
                    FirstName = "FirstName 6",
                    LastName = "LastName 6",
                    Email = "Contact6@gmail.com",
                    AccountId = 3
                }
            );
        }
    }
}
