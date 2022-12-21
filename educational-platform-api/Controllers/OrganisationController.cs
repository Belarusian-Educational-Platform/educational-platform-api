using educational_platform_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace educational_platform_api.Controllers
{
    [ApiController]
    [Route("/organisation")]
    public class OrganisationController : ControllerBase
    {
        [HttpGet("get-all")]
        public List<Organisation> GetAllOrganisations()
        {
            return new List<Organisation>();
        }

        [HttpGet("get-by-id")]
        public Organisation GetOrganisation(int organisationId)
        {
            return new Organisation();
        }

        [HttpPost("post")]
        public ActionResult PostOrganisation([FromBody] Organisation organisation)
        {
            return Ok(organisation);
        }

        [HttpPut("put")]
        public ActionResult PutOrganisation([FromBody] Organisation organisation)
        {
            return Ok(organisation);
        }

        [HttpDelete("delete")]
        public ActionResult DeleteOrganisation(int organisationId)
        {
            return Ok(organisationId);
        }
    }
}
