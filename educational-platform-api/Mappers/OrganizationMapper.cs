using educational_platform_api.DTOs;
using educational_platform_api.Models;
using System.Globalization;

namespace educational_platform_api.Mappers
{
    public class OrganizationMapper : AutoMapper.Profile
    {
        public OrganizationMapper()
        {
            CreateMap<CreateOrganizationInput, Organization>();

            CreateMap<UpdateOrganizationInput, Organization>();
        }
    }
}
