using educational_platform_api.DTOs.Relations;
using educational_platform_api.Models;

namespace educational_platform_api.Mappers
{
    public class ProfileGroupRelationMapper : AutoMapper.Profile
    {
        public ProfileGroupRelationMapper()
        {
            CreateMap<CreateProfileGroupRelationInput, ProfileGroupRelation>();
        }
    }
}
