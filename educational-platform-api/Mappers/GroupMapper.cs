using educational_platform_api.DTOs.Group;
using educational_platform_api.Models;

namespace educational_platform_api.Mappers
{
    public class GroupMapper : AutoMapper.Profile
    {
        public GroupMapper()
        {
            CreateMap<CreateGroupInput, Group>();

            CreateMap<UpdateGroupInput, Group>();
        }
    }
}
