﻿using educational_platform_api.DTOs;
using educational_platform_api.Models;

namespace educational_platform_api.Services
{
    public interface IProfileService
    {
        public IEnumerable<Profile> GetProfiles();
        public Profile GetProfileById(int id);
        public IEnumerable<Profile> GetAccountProfiles(string keycloakId);
        public Profile GetActiveProfile(string keycloakId);

        public Profile CreateProfile(CreateProfileInput profileInput);
        public void UpdateProfile(UpdateProfileInput profileInput);
        public void DeleteProfile(int id);
    }
}
