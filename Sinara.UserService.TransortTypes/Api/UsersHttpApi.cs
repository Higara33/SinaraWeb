using Sinara.Core;
using Sinara.Core.Attributes;
using Sinara.Core.Managers.Contracts;
using Sinara.Core.Services;
using Sinara.Core.Types.Api.ViewModels;
using Sinara.UserService.TransortTypes.Api.Contracts;
using Sinara.UserService.TransortTypes.Models.FormModels;

namespace Sinara.UserService.TransortTypes.Api
{
    [HttpService("UserService", "Users", Constants.AreaMvc.Api)]
    public class UsersHttpApi : HttpServiceBase, IUsersHttpApi
    {
        public UsersHttpApi(IConfigurationManager cfg) : base(cfg)
        {
        }

        public async Task<ApiResult> AddUser([ToBody] AddUserFormModel model)
        {
            return await PostAsync<ApiResult>(model);
        }

        public async Task<ApiResult> DeleteUser([ToIndex] string login)
        {
            return await DeleteAsync<ApiResult>(login);
        }

        public async Task<ApiResult> EditUser([ToBody] EditUserFormModel model)
        {
            return await PostAsync<ApiResult>(model);
        }

        public async Task<ApiResult> GetUsers(bool deleted = false)
        {
            return await GetAsync<ApiResult>(deleted);
        }

    }
}
