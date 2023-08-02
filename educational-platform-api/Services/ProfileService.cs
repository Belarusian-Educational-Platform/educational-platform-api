﻿using educational_platform_api.DTOs.Profile;
using educational_platform_api.Models;
using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AutoMapper.IMapper _mapper;

        public ProfileService(UnitOfWork unitOfWork,
            AutoMapper.IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Profile GetProfileById(int id)
        {
            return _unitOfWork.Profiles.GetById(id);
        }

        public Profile GetActiveProfile(string keycloakId)
        {
            return _unitOfWork.Profiles.GetActiveByAccount(keycloakId);
        }

        public IEnumerable<Profile> GetAllProfiles()
        {
            return _unitOfWork.Profiles.GetAll();
        }

        public IEnumerable<Profile> GetAccountProfiles(string keycloakId)
        {
            return _unitOfWork.Profiles.GetByAccount(keycloakId);
        }

        public IEnumerable<Profile> GetMyOrganizationProfiles(int profileId)
        {
            var organization = _unitOfWork.Organizations.GetByProfileId(profileId);
            var organizationProfiles = _unitOfWork.Profiles.GetByOrganizationId(organization.Id);

            return organizationProfiles;
        }

        public Profile CreateProfile(CreateProfileInput input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var profile = _mapper.Map<Profile>(input);
                    var profileEntity = _unitOfWork.Profiles.Create(profile);
                    _unitOfWork.Save();

                    var relation = new ProfileOrganizationRelation()
                    {
                        ProfileId = profileEntity.Id,
                        OrganizationId = input.OrganizationId,
                        Permissions = "[]"
                    };
                    _unitOfWork.ProfileOrganizationRelations.Create(relation);

                    _unitOfWork.Save();

                    return profileEntity;
                } catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex; 
                }
            }
        }

        public void UpdateProfile(UpdateProfileInput input)
        {
            var profile = _mapper.Map<Profile>(input);
            _unitOfWork.Profiles.Update(profile);
            _unitOfWork.Save();
        }

        public void DeleteProfile(int id)
        {
            // TODO: CASCADE DELETE IMPLEMENTATION
        }

        public IEnumerable<Profile> GetGroupProfiles(int groupId)
        {
            return _unitOfWork.Profiles.GetByGroupId(groupId);
        }
    }
}
