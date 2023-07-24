using educational_platform_api.Types.Enums;

namespace educational_platform_api.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public ProfileType Type { get; set; }
        public int OrganizationId { get; set; }
        public string KeycloakId { get; set; }
        public bool IsActive { get; set; }
    }
}
