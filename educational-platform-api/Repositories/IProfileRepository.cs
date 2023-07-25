﻿using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IProfileRepository
    {
        public IEnumerable<Profile> GetProfiles();
        public Profile GetProfile(int id);
        public IEnumerable<Profile> GetAccountProfiles(string keycloakId);
        public Profile GetActiveProfile(string keycloakId);

        public Profile CreateProfile(Profile profile);
        public Profile UpdateProfile(Profile profile);
        public bool DeleteProfile(int id);
    }
}
