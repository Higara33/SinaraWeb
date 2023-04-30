using Sinara.Core.Types.Api.Extensions;
using Sinara.Core.Types.Api.ViewModels;
using Sinara.UserService.DBConnect;
using Sinara.UserService.TransortTypes.Api.Contracts;
using Sinara.UserService.TransortTypes.Models.FormModels;
using Sinara.UserService.TransortTypes.Models.ViewModels;

namespace Sinara.UserService.Api
{
    public class UsersHttpApi : IUsersHttpApi
    {
        public async Task<ApiResult> GetUsers(bool deleted = false)
        {
            using (var context = new DbProvider())
            {
                if (!deleted)
                {
                    if (context.Users.ToList().Count == 0)
                        return new ApiResult().Error("no_users_in_note", $"There are no users in note");

                    var notDeletedUsers = context.Users.ToList().Where(x => !x.Deleted).ToList();

                    if (notDeletedUsers.Count == 0)
                        return new ApiResult().Error("operation_with_deleted_users", $"There are no users in note");

                    return new ApiResult().Ok(notDeletedUsers);
                }
                else
                    return new ApiResult().Error("operation_with_deleted_users", $"You do not have permission to view deleted users");
            }
        }

        public async Task<ApiResult> EditUser(EditUserFormModel model)
        {
            if (model.Login == string.Empty)
                return new ApiResult().Error("login_is_Empty", $"Login is Empty");

            if (model.FirstName == string.Empty && model.LastName == string.Empty && model.FatherName == string.Empty && model.NewLogin == string.Empty)
                return new ApiResult().Error("no_data_to_edit", $"No data to edit!");

            using (var context = new DbProvider())
            {
                UserViewModel user1;

                var notDeletedUsers = context.Users.ToList().Where(x => !x.Deleted).ToList();

                if (!notDeletedUsers.Any(x => x.Login == model.Login))
                    return new ApiResult().Error("user_not_found", $"User with Login={model.Login} is not found");

                var userInList = notDeletedUsers.SingleOrDefault(x => x.Login == model.Login);

                if (userInList == null)
                    return new ApiResult().Error("user_not_found", $"User with Login={model.Login} is not found");

                if (notDeletedUsers.Any(x => x.Login == model.NewLogin))
                    return new ApiResult().Error("the_same_login", $"User with Login={model.NewLogin} already exists");

                var user = context.Users.Find(userInList.Id);

                if (model.FirstName != string.Empty)
                    user.FirstName = model.FirstName;

                if (model.LastName != string.Empty)
                    user.LastName = model.LastName;

                if (model.FatherName != string.Empty)
                    user.FatherName = model.FatherName;

                if (model.NewLogin != string.Empty)
                    user.Login = model.NewLogin;

                context.SaveChanges();
            }

            return new ApiResult().Ok();
        }

        public async Task<ApiResult> AddUser(AddUserFormModel model)
        {
            if (model.Login == string.Empty)
                return new ApiResult().Error("login_is_Empty", $"Login is Empty");

            if (model.LastName == string.Empty)
                return new ApiResult().Error("lastName_is_Empty", $"LastName is Empty");

            if (model.FatherName == string.Empty)
                return new ApiResult().Error("fatherName_is_Empty", $"FatherName is Empty");

            if (model.FirstName == string.Empty)
                return new ApiResult().Error("firstName_is_Empty", $"FirstName is Empty");

            using (var context = new DbProvider())
            {
                var userList = context.Users.ToList();
                foreach(var item in userList) 
                {
                    if(item.Login == model.Login && !item.Deleted)
                        return new ApiResult().Error("the_same_login_with_user", $"User with Login={model.Login} already exists");

                    if (item.Login == model.Login && item.Deleted)
                        return new ApiResult().Error("operation_with_deleted_users", $"User with Login={model.Login} once existed");
                }

                var user = new UserViewModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    FatherName = model.FatherName,
                    Login = model.Login
                };

                context.Users.Add(user);
                context.SaveChanges();
            }

            return new ApiResult().Ok();
        }

        public  async Task<ApiResult> DeleteUser(string login)
        {
            using (var context = new DbProvider())
            {
                var notDeletedUsers = context.Users.ToList().Where(x => !x.Deleted).ToList();

                if (notDeletedUsers.Count == 0)
                    return new ApiResult().Error("No_not_deleted_users", $"User with Login={login} is not found");

                var user = notDeletedUsers.Where(x => x.Login == login).SingleOrDefault();
                if (user == null)
                    return new ApiResult().Error("user_not_found", $"User with Login={login} is not found");

                context.Users.Find(user.Id).Deleted = true;

                context.SaveChanges();
            }

            return new ApiResult().Ok();
        }

    }
}
