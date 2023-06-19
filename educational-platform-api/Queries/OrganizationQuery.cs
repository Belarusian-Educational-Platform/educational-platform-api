using educational_platform_api.Models;
using educational_platform_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace educational_platform_api.Queries
{
    [ApiController]
    [Route("/organisation")]
    public class OrganizationQuery : ControllerBase
    {
        private readonly IOrganizationService organizationService;

        public OrganizationQuery(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        [HttpGet("get-page")]
        public List<Organization> GetOrganizationsPage(int page, int size)
        {
            return new List<Organization>();
        }

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
