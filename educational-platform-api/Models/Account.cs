namespace educational_platform_api.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string KeycloakId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
    }
}
