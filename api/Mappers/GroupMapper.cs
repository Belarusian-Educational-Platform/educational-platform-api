using api.DTOs.Group;
using api.Models;

namespace api.Mappers
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
