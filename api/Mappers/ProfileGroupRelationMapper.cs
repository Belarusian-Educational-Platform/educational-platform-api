using api.DTOs.Relations;
using api.Models;

namespace api.Mappers
{
    public class ProfileGroupRelationMapper : AutoMapper.Profile
    {
        public ProfileGroupRelationMapper()
        {
            CreateMap<CreateProfileGroupRelationInput, ProfileGroupRelation>();
            CreateMap<UpdateProfileGroupRelationInput, ProfileGroupRelation>();
        }
    }
}
