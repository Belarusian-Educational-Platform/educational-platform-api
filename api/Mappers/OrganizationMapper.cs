using api.DTOs.Organization;
using api.Models;
using System.Globalization;

namespace api.Mappers
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
