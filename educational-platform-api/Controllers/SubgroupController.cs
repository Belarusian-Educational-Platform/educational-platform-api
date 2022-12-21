using educational_platform_api.Models;
using educational_platform_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace educational_platform_api.Controllers
{
    [ApiController]
    [Route("/subgroup")]
    public class SubgroupController : ControllerBase
    {
        private readonly ISubgroupService subgroupService;

        public SubgroupController(ISubgroupService subgroupService)
        {
            this.subgroupService = subgroupService;
        }

        [HttpGet("get-all")]
        public List<Subgroup> GetAllSubgroups()
        {
            return new List<Subgroup>();
        }

        [HttpGet("get-by-id")]
        public Subgroup GetSubgroup(int subgroupId)
        {
            return new Subgroup();
        }

        [HttpPost("post")]
        public ActionResult PostSubgroup([FromBody] Subgroup subgroup)
        {
            return Ok(subgroup);
        }

        [HttpPut("put")]
        public ActionResult PutSubgroup([FromBody] Subgroup subgroup)
        {
            return Ok(subgroup);
        }

        [HttpDelete("delete")]
        public ActionResult DeleteSubgroup(int subgroupId)
        {
            return Ok(subgroupId);
        }
    }
}
