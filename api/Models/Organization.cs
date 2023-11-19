using api.Models.Base;

namespace api.Models
{
    public class Organization : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<ProfileOrganizationRelation> ProfileRelations { get; set; }
        public ICollection<GroupOrganizationRelation> GroupRelations { get; set; }
    }
}
