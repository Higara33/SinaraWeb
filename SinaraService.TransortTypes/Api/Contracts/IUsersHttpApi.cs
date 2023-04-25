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
        Task<ApiResult> EditUser(string firstName, string lastName, string fatherName, string login);
        Task<ApiResult> DeleteUser(string login);
        Task<ApiResult> AddUser(string firstName, string lastName, string fatherName, string login);
    }
}
