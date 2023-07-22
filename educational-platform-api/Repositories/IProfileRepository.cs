﻿using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IProfileRepository
    {
        public IEnumerable<Profile> GetProfiles();
        public Profile GetProfile(int id);
        public Profile GetActiveProfile(string keycloakId);
    }
}
