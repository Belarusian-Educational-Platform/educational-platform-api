namespace educational_platform_api.Models
{
    public class UserGroupRelation
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string? Role { get; set; }
    }
}
