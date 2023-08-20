namespace educational_platform_api.DTOs.Relations
{
    public class UpdateProfileOrganizationRelationInput
    {
        public int ProfileId { get; set; }
        public int OrganizationId { get; set; }
        public string Permissions { get; set; }
    }
}
