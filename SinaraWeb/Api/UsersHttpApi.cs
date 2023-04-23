using Microsoft.AspNetCore.Mvc;
using Sinara.Core.Types.Api.ViewModels;
using Sinara.UserService.TransortTypes.Api.Contracts;

namespace Sinara.UserService.Api
{
    public class UsersHttpApi : IUsersHttpApi
    {
        public async Task<ApiResult> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult> EditUser()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult> AddUser()
        {
            throw new NotImplementedException();
        }

        public  async Task<ApiResult> DeleteUser()
        {
            throw new NotImplementedException();
        }
    }
}
