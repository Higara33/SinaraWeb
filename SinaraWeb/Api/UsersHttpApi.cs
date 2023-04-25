using Microsoft.AspNetCore.Mvc;
using Sinara.Core.Types.Api.Extensions;
using Sinara.Core.Types.Api.ViewModels;
using Sinara.UserService.Models;
using Sinara.UserService.TransortTypes.Api.Contracts;
using SinaraWeb.DBConnect;

namespace Sinara.UserService.Api
{
    public class UsersHttpApi : IUsersHttpApi
    {
        public async Task<ApiResult> GetAllUsers()
        {
            using (var context = new ApiContext())
            {
                var list = context.Users.ToList();
                return new ApiResult().Ok(list);
            }
        }

        public async Task<ApiResult> EditUser(string login)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult> AddUser(string firstName, string lastName, string fatherName, string login)
        {
            using (var context = new ApiContext())
            {
                var user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    FatherName = fatherName,
                    Login =  login 
                };

                context.Users.Add(user);
                context.SaveChanges();
            }

            return new ApiResult().Ok();
        }

        public  async Task<ApiResult> DeleteUser(string login)
        {
            using (var context = new ApiContext())
            {
                var list = context.Users.ToList();

                context.Users.Remove(context.Users.Find(login));

                context.SaveChanges();
            }

            return new ApiResult().Ok();
        }
    }
}
