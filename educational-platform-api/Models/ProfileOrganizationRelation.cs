namespace educational_platform_api.Models
{
    public class ProfileOrganizationRelation
    {
        public int ProfileId { get; set; }
        public int OrganizationId { get; set; }
        public string Permissions { get; set; }
    }
}
