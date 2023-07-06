namespace educational_platform_api.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ProfileType { get; set; }
        public int OrganizationId { get; set; }
        public int AccountId { get; set; }
    }
}
