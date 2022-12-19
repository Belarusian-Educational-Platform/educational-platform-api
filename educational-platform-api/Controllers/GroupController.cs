using educational_platform_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace educational_platform_api.Controllers
{
    [ApiController]
    [Route("/group")]
    public class GroupController : ControllerBase
    {
        [HttpGet("get")]
        public Group GetGroup()
        {
            return new Group();
        }

        [HttpPost("post")]
        public ActionResult PostGroup(Group group)
        {
            return Ok(group);
        }

        [HttpPut("put")]
        public ActionResult PutGroup(Group group)
        {
            return Ok(group);
        }

        [HttpDelete("delete")]
        public ActionResult DeleteGroup(int groupId)
        {
            return Ok(groupId);
        }
    }
}
