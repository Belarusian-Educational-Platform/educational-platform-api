using api.DTOs.Relations;
using api.Models;

namespace api.Mappers
{
    public class ProfileOrganizationRelationMapper : AutoMapper.Profile
    {
        public ProfileOrganizationRelationMapper()
        {
            CreateMap<UpdateProfileOrganizationRelationInput, ProfileOrganizationRelation>();
        }
    }
}
