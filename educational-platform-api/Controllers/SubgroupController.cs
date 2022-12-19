using educational_platform_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace educational_platform_api.Controllers
{
    [ApiController]
    [Route("/subgroup")]
    public class SubgroupController : ControllerBase
    {
        [HttpGet("get")]
        public Subgroup GetSubgroup()
        {
            return new Subgroup();
        }

        [HttpPost("post")]
        public ActionResult PostSubgroup(Subgroup subgroup)
        {
            return Ok(subgroup);
        }

        [HttpPut("put")]
        public ActionResult PutSubgroup(Subgroup subgroup)
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
