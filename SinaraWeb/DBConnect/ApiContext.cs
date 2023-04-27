using Microsoft.EntityFrameworkCore;
using Sinara.UserService.TransortTypes.Models;

namespace SinaraWeb.DBConnect
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "UsersDb");
        }
        public DbSet<User> Users { get; set; }
    }
}
