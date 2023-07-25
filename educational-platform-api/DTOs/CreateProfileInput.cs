using educational_platform_api.Types.Enums;

namespace educational_platform_api.DTOs
{
    public class CreateProfileInput
    {
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public ProfileType Type { get; set; }
        public int OrganizationId { get; set; }
    }
}
