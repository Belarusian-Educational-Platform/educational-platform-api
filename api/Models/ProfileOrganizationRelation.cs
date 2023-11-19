using api.Models.Base;

namespace api.Models
{
    public class ProfileOrganizationRelation : EntityBase
    {
        public int ProfileId { get; set; }
        public int OrganizationId { get; set; }
        public string Permissions { get; set; }

        public Profile Profile { get; set; }
        public Organization Organization { get; set; }
    }
}
