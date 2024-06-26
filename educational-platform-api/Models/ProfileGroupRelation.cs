﻿using educational_platform_api.Models.Base;
using educational_platform_api.Types.Enums;

namespace educational_platform_api.Models
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
