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

                if(list.Count == 0)
                    return new ApiResult().Error("no_users_in_note", $"There are no users in note");

                return new ApiResult().Ok(list);
            }
        }

        public async Task<ApiResult> EditUser(string login, string firstName = null, string lastName = null, string fatherName = null, string newLogin = null)
        {
            if (login == null)
                return new ApiResult().Error("login_is_null", $"Login=Null");

            if (firstName == null && lastName == null && fatherName == null && newLogin == null)
                return new ApiResult().Error("no_data_to_edit", $"No data to edit!");

            using (var context = new ApiContext())
            {
                var userList = context.Users.ToList();
                if (!userList.Any(x => x.Login == login))
                    return new ApiResult().Error("user_not_found", $"User with Login={login} is not found");

                if (userList.Any(x => x.Login == newLogin))
                    return new ApiResult().Error("the_same_login_with_user", $"User with Login={newLogin} already exists");

                var id = userList.Where(x => x.Login == login).First().Id;

                if (firstName != null)
                    context.Users.Find(id).FirstName = firstName;

                if (lastName != null)
                    context.Users.Find(id).LastName = lastName;

                if (fatherName != null)
                    context.Users.Find(id).FatherName = fatherName;

                if (newLogin != null)
                    context.Users.Find(id).Login = newLogin;

                context.SaveChanges();
            }

            return new ApiResult().Ok();
        }

        public async Task<ApiResult> AddUser(string firstName, string lastName, string fatherName, string login)
        {
            if (login == null)
                return new ApiResult().Error("login_is_null", $"Login=Null");

            if (lastName == null)
                return new ApiResult().Error("lastName_is_null", $"LastName=Null");

            if (fatherName == null)
                return new ApiResult().Error("fatherName_is_null", $"FatherName=Null");

            if (firstName == null)
                return new ApiResult().Error("firstName_is_null", $"FirstName=Null");

            using (var context = new ApiContext())
            {
                var userList = context.Users.ToList();
                foreach(var item in userList) 
                {
                    if(item.Login == login)
                        return new ApiResult().Error("the_same_login_with_user", $"User with Login={login} already exists");
                }

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
                var userList = context.Users.ToList();
                
                if (!userList.Any(x => x.Login == login))
                    return new ApiResult().Error("user_not_found", $"User with Login={login} is not found");

                var id = userList.Where(x => x.Login == login).First().Id;

                context.Users.Remove(context.Users.Find(id));

                context.SaveChanges();
            }

            return new ApiResult().Ok();
        }
    }
}
