using educational_platform_api.Types.Enums;

namespace educational_platform_api.DTOs.Relations
{
    public class UpdateProfileGroupRelationInput
    {
        public int ProfileId { get; set; }
        public int GroupId { get; set; }
        public Role ProfileRole { get; set; }
        public string Permissions { get; set; }
    }
}
