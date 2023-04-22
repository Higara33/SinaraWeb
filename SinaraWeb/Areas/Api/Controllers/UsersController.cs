using Microsoft.AspNetCore.Mvc;
using SinaraWeb.DBConnect.Interfaces;
using SinaraWeb.DBConnect.Models;

namespace Sinara.UserService.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return Ok(_userRepository.GetUsers());
        }
    }
}
