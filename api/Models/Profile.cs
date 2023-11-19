using api.Models.Base;
using api.Types.Enums;

namespace api.Models
{
    public class Profile : EntityBase
    {
        public int Id { get; set; }
        public string KeycloakId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthday { get; set; }

        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }

        public ProfileType Type { get; set; }
        public bool IsActive { get; set; }

        public ProfileOrganizationRelation OrganizationRelation { get; set; }
        public ICollection<ProfileGroupRelation> GroupRelations { get; set; }
    }
}
