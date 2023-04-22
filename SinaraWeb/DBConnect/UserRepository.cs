using SinaraWeb.DBConnect;
using SinaraWeb.DBConnect.Interfaces;
using SinaraWeb.DBConnect.Models;

namespace SinaraService.DBConnect
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
            using (var context = new ApiContext())
            {
                var users = new List<User>
                {
                    new User
                    {
                        Name = "Denis",
                        SurName = "Kuzin",
                        FatherName = "NoIdea",
                        Login = new ActiveDirectory { Login = "Gmih228", Domain = "Govno.com" }
                    },
                    new User
                    {
                        Name = "Andrei",
                        SurName = "Kuzmin",
                        FatherName = "Aleksandrovich",
                        Login = new ActiveDirectory { Login = "Higara33", Domain = "Govno.com" }
                    }
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }

        public List<User> GetUsers()
        {
            using (var context = new ApiContext())
            {
                var list = context.Users.ToList();
                return list;
            }
        }
    }
}
