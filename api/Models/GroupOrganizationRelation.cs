using api.Models.Base;

namespace api.Models
{
    public class GroupOrganizationRelation : EntityBase
    {
        public int GroupId { get; set; }
        public int OrganizationId { get; set; }

        public Group Group { get; set; }
        public Organization Organization { get; set; }
    }
}
