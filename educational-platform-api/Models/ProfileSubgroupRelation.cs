using educational_platform_api.Types.Enums;

namespace educational_platform_api.Models
{
    public class ProfileSubgroupRelation
    {
        public int ProfileId { get; set; }
        public int SubgroupId { get; set; }
        public Role ProfileRole { get; set; }
        public string Permissions { get; set; }
    }
}
