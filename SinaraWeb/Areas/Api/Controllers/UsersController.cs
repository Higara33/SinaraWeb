using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Sinara.Core;
using Sinara.Core.Types.Api.ViewModels;
using Sinara.UserService.TransortTypes.Api.Contracts;
using Sinara.UserService.TransortTypes.Models.FormModels;

namespace Sinara.UserService.Areas.Api.Controllers
{
    [ApiController]
    [Area(Constants.AreaMvc.Api)]
    [Route("/[area]/[controller]")]
    public class UsersController : Controller, IUsersHttpApi
    {
        private readonly IUsersHttpApi _usersHttpApi;

        public UsersController(IUsersHttpApi usersHttpApi) 
        {
            _usersHttpApi = usersHttpApi;
        }

        [HttpPost("AddUser")]
        public async Task<ApiResult> AddUser([FromBody] AddUserFormModel model)
        {
            return await _usersHttpApi.AddUser(model);
        }

        [HttpDelete("DeleteUser/{login}")]
        public async Task<ApiResult> DeleteUser(string login)
        {
            return await _usersHttpApi.DeleteUser(login);
        }

        [HttpPost("EditUser")]
        public async Task<ApiResult> EditUser([FromBody] EditUserFormModel model)
        {
            return await _usersHttpApi.EditUser(model);
        }

        [HttpGet("GetUsers")]
        public async Task<ApiResult> GetUsers(bool deleted)
        {
            return await _usersHttpApi.GetUsers(deleted);
        }
    }
}
