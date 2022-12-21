using educational_platform_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace educational_platform_api.Controllers
{
    [ApiController]
    [Route("/organisation")]
    public class OrganizationController : ControllerBase
    {
        [HttpGet("get-all")]
        public List<Organization> GetAllOrganisations()
        {
            return new List<Organization>();
        }

        [HttpGet("get-by-id")]
        public Organization GetOrganisation(int organisationId)
        {
            return new Organization();
        }

        [HttpPost("post")]
        public ActionResult PostOrganisation([FromBody] Organization organisation)
        {
            return Ok(organisation);
        }

        [HttpPut("put")]
        public ActionResult PutOrganisation([FromBody] Organization organisation)
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
