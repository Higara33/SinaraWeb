using Sinara.Core.Types.Api.ViewModels;
using Sinara.UserService.TransortTypes.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinara.UserService.TransortTypes.Api.Contracts
{
    public interface IUsersHttpApi
    {
        Task<ApiResult> GetUsers(bool deleted = false);
        Task<ApiResult> EditUser(EditUserFormModel model);
        Task<ApiResult> DeleteUser(string login);
        Task<ApiResult> AddUser(AddUserFormModel model);
    }
}
