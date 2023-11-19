using api.Models.Base;
using api.Types.Enums;

namespace api.Models
{
    public class ProfileGroupRelation : EntityBase
    {
        public int ProfileId { get; set; }
        public int GroupId { get; set; }
        public Role ProfileRole { get; set; }
        public string Permissions { get; set; }

        public Profile Profile { get; set; }
        public Group Group { get; set; }
    }
}
