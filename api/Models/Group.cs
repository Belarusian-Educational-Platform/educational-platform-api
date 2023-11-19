using api.Models.Base;

namespace api.Models
{
    public class Group : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GroupOrganizationRelation OrganizationRelation { get; set; }
        public ICollection<ProfileGroupRelation> ProfileRelations { get; set; }
    }
}
