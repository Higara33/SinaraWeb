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

        public async Task<ApiResult> AddUser(string firstName, string lastName, string fatherName, string login)
        {
            return await PostAsync<ApiResult>(firstName, lastName, fatherName, login);
        }

        public async Task<ApiResult> DeleteUser([ToIndex]string login)
        {
            return await DeleteAsync<ApiResult>(login);
        }

        public async Task<ApiResult> EditUser(string login, string firstName = null, string lastName = null, string fatherName = null, string newLogin = null)
        {
            return await PostAsync<ApiResult>(login, firstName, lastName, fatherName, newLogin);
        }

        public async Task<ApiResult> GetUsers(bool deleted = false)
        {
            return await GetAsync<ApiResult>(deleted);
        }

    }
}
