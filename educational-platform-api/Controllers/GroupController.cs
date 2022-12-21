using educational_platform_api.Models;
using educational_platform_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace educational_platform_api.Controllers
{
    [ApiController]
    [Route("/group")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService groupService;

        public GroupController (IGroupService groupService)
        {
            this.groupService = groupService;
        }

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
