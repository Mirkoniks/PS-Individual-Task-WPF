using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Data.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
        public DbSet<SchoolRecord> SchoolRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseName = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseName);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

            //User user1 = new User();

            //var user = new User()
            //{
            //    Id = 1,
            //    Name = "John Doe",
            //    Password = user1.Encrypt("password"),
            //    Role = UserRoleEnum.ADMIN,
            //    Expires = DateTime.Now.AddYears(10),
            //    BirthDay = DateTime.UtcNow,
            //    Email = "sa@a.bg",
            //    StudentNumber = "5697"
            //};

            //modelBuilder.Entity<DatabaseUser>().HasData(user);

            base.OnModelCreating(modelBuilder);
        }
    }
}
