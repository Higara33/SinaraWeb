using SinaraWeb.DBConnect.Models;

namespace SinaraWeb.DBConnect.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetUsers();
    }
}
