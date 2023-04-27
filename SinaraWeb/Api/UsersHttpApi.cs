using Microsoft.AspNetCore.Mvc;
using Sinara.Core.Types.Api.Extensions;
using Sinara.Core.Types.Api.ViewModels;
using Sinara.UserService.TransortTypes.Models;
using Sinara.UserService.TransortTypes.Api.Contracts;
using SinaraWeb.DBConnect;
using System.Collections.Generic;

namespace Sinara.UserService.Api
{
    public class UsersHttpApi : IUsersHttpApi
    {
        public async Task<ApiResult> GetUsers()
        {
            using (var context = new ApiContext())
            {
                if (context.Users.ToList().Count == 0)
                    return new ApiResult().Error("no_users_in_note", $"There are no users in note");

                var notDeletedUsers = GetNotDeletedUsers();

                if (notDeletedUsers.Count == 0)
                    return new ApiResult().Error("operetion_with_deleted_users", $"There are no users in note");

                return new ApiResult().Ok(notDeletedUsers);
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
                var notDeletedUsers = GetNotDeletedUsers();

                if (notDeletedUsers.Count == 0)
                    return new ApiResult().Error("No_not_deleted_users", $"User with Login={login} is not found");

                if (!notDeletedUsers.Any(x => x.Login == login))
                    return new ApiResult().Error("user_not_found", $"User with Login={login} is not found");

                if (notDeletedUsers.Any(x => x.Login == newLogin))
                    return new ApiResult().Error("the_same_login", $"User with Login={newLogin} already exists");

                var id = notDeletedUsers.Where(x => x.Login == login).First().Id;

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
                    if(item.Login == login && !item.Deleted)
                        return new ApiResult().Error("the_same_login_with_user", $"User with Login={login} already exists");

                    if (item.Login == login && item.Deleted)
                        return new ApiResult().Error("operetion_with_deleted_users", $"User with Login={login} once existed");
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
                var notDeletedUsers = GetNotDeletedUsers();

                if (notDeletedUsers.Count == 0)
                    return new ApiResult().Error("No_not_deleted_users", $"User with Login={login} is not found");

                var user = notDeletedUsers.Where(x => x.Login == login).FirstOrDefault();
                if (user == null)
                    return new ApiResult().Error("user_not_found", $"User with Login={login} is not found");

                context.Users.Find(user.Id).Deleted = true;

                context.SaveChanges();
            }

            return new ApiResult().Ok();
        }

        #region Private

        private List<User> GetNotDeletedUsers()
        {
            using (var context = new ApiContext())
            {
                var allUsersList = context.Users.ToList();
                var notDeletedUsersList = context.Users.ToList();

                if (allUsersList.Count == 0)
                    return allUsersList;

                foreach (var user in allUsersList) 
                {
                    if (user.Deleted)
                        notDeletedUsersList.Remove(user);
                }

                if (notDeletedUsersList.Count == 0)
                    return notDeletedUsersList;

                return notDeletedUsersList;
            }
        }

        #endregion
    }
}
