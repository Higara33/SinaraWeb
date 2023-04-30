using Microsoft.EntityFrameworkCore;
using Sinara.UserService.TransortTypes.Models.ViewModels;

namespace Sinara.UserService.DBConnect
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "UsersDb");
        }
        public DbSet<UserViewModel> Users { get; set; }
    }
}
