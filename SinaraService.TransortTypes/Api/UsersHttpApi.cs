using Sinara.Core;
using Sinara.Core.Attributes;
using Sinara.Core.Managers.Contracts;
using Sinara.Core.Services;
using Sinara.Core.Types.Api.ViewModels;
using Sinara.UserService.TransortTypes.Api.Contracts;

namespace Sinara.UserService.TransortTypes.Api
{
    [HttpService("UserService", "Users", Constants.AreaMvc.Api)]
    public class UsersHttpApi : HttpServiceBase, IUsersHttpApi
    {
        public UsersHttpApi(IConfigurationManager cfg) : base(cfg)
        {
        }

        public async Task<ApiResult> AddUser()
        {
            return await PostAsync<ApiResult>();
        }

        public async Task<ApiResult> DeleteUser()
        {
            return await DeleteAsync<ApiResult>();
        }

        public async Task<ApiResult> EditUser()
        {
            return await PostAsync<ApiResult>();
        }

        public async Task<ApiResult> GetAllUsers()
        {
            return await GetAsync<ApiResult>();
        }

    }
}
