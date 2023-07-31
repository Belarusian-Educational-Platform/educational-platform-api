using educational_platform_api.DTOs.Subgroup;
using educational_platform_api.Models;

namespace educational_platform_api.Mappers
{
    public class SubgroupMapper : AutoMapper.Profile
    {
        public SubgroupMapper()
        {
            CreateMap<CreateSubgroupInput, Subgroup>();

            CreateMap<UpdateSubgroupInput, Subgroup>();
        }
    }
}
