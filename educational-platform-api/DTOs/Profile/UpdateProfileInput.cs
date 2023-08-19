using educational_platform_api.Types.Enums;

namespace educational_platform_api.DTOs.Profile
{
    public class UpdateProfileInput
    {
        public int Id { get; set; }
        public string? KeycloakId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Surname { get; set; }
        public string? Birthday { get; set; }

        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }

        public ProfileType? Type { get; set; }
        public bool? IsActive { get; set; }
    }
}
