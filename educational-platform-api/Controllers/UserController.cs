using educational_platform_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace educational_platform_api.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        [HttpGet("get")]
        public User GetUser()
        {
            return new User();
        }

        [HttpPost("post")]
        public ActionResult PostUser(User user)
        {
            return Ok(user);
        }

        [HttpPut("put")]
        public ActionResult PutUser(User user)
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
