﻿using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IGroupOrganizationRelationRepository
    {
        public void CreateRelation(GroupOrganizationRelation relation);
    }
}
