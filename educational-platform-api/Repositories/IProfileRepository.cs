﻿using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IProfileRepository
    {
        public IEnumerable<Profile> GetAll();
        public Profile GetById(int id);
        public IEnumerable<Profile> GetByAccount(string keycloakId);
        public Profile GetActiveByAccount(string keycloakId);
        public IEnumerable<Profile> GetByOrganizationId(int organizationId);

        public Profile Create(Profile profile);
        public void Update(Profile profile);
        public void Delete(Profile profile);
    }
}
