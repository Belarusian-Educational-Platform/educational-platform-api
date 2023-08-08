﻿namespace educational_platform_api.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GroupOrganizationRelation OrganizationRelation { get; set; }
        public ICollection<ProfileGroupRelation> ProfileRelations { get; set; }
    }
}
