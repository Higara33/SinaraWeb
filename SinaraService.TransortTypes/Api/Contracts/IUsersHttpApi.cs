using Sinara.Core.Types.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinara.UserService.TransortTypes.Api.Contracts
{
    public interface IUsersHttpApi
    {
        Task<ApiResult> GetAllUsers();
        Task<ApiResult> EditUser();
        Task<ApiResult> DeleteUser();
        Task<ApiResult> AddUser();
    }
}
