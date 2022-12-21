using educational_platform_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace educational_platform_api.Controllers
{
    [ApiController]
    [Route("/group")]
    public class GroupController : ControllerBase
    {
        [HttpGet("get-all")]
        public List<Group> GetAllGroups()
        {
            return new List<Group>();
        }

        [HttpGet("get-by-id")]
        public Group GetGroup(int groupId)
        {
            return new Group();
        }

        [HttpPost("post")]
        public ActionResult PostGroup([FromBody] Group group)
        {
            return Ok(group);
        }

        [HttpPut("put")]
        public ActionResult PutGroup([FromBody] Group group)
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
