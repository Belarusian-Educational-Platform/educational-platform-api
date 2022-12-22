using educational_platform_api.Models;
using educational_platform_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace educational_platform_api.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("get-page")]
        public List<User> GetUsersPage(int page, int size)
        {
            return new List<User>();
        }

        [HttpGet("get-all")]
        public List<User> GetAllUsers()
        {
            return new List<User>();
        }

        [HttpGet("get-by-id")]
        public User GetUser(int userId)
        {
            return new User();
        }

        [HttpPost("post")]
        public ActionResult PostUser([FromBody] User user)
        {
            return Ok(user);
        }

        [HttpPut("put")]
        public ActionResult PutUser([FromBody] User user)
        {
            return Ok(user);
        }

        [HttpDelete("delete")]
        public ActionResult DeleteUser(int userId)
        {
            return Ok(userId);
        }
    }
}
