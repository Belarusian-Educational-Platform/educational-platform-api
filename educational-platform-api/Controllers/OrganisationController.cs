using educational_platform_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace educational_platform_api.Controllers
{
    [ApiController]
    [Route("/organisation")]
    public class OrganisationController : ControllerBase
    {
        [HttpGet("get")]
        public Organisation GetOrganisation()
        {
            return new Organisation();
        }

        [HttpPost("post")]
        public ActionResult PostOrganisation(Organisation organisation)
        {
            return Ok(organisation);
        }

        [HttpPut("put")]
        public ActionResult PutOrganisation(Organisation organisation)
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
