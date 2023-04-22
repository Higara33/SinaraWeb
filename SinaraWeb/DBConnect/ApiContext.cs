using Microsoft.EntityFrameworkCore;
using SinaraWeb.DBConnect.Models;

namespace SinaraWeb.DBConnect
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        }
        public DbSet<User> Users { get; set; }
    }
}
