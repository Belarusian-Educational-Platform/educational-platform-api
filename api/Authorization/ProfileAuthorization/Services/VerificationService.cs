using api.Exceptions.RepositoryExceptions;
using api.Models;
using api.Services;
using Microsoft.EntityFrameworkCore;

namespace ProfileAuthorization
{
    public class VerificationService : IVerificationService
    {
        private readonly IPermissionService _permissionService;
        private readonly IProfileService _profileService;
        private readonly IGroupService _groupService;

        private PermissionSet _permissions = new();
        private VerificationOptions _options = new();

        public VerificationService(IPermissionService permissionService,
            IProfileService profileService,
            IGroupService groupService)
        {
            _permissionService = permissionService;
            _profileService = profileService;
            _groupService = groupService;
        }
        
        public bool Assert(params Permission[] requirements)
        {
            foreach (var requirement in requirements) {
                if (!_permissions.HasPermission(requirement)) {
                    return false;
                }
            }

            return true;
        }

        public bool Assert(AssertionPredicate assertion)
        {
            return assertion(_permissions.HasPermission);
        }

        public bool RequireOrganizationCorrespondence(CorrespondsWith correspondsWith, int id)
        {
            var primaryProfile = _profileService.GetById(_options.ProfileId)
                .Include(p => p.OrganizationRelation)
                .FirstOrDefault();
            int primaryOrganizationId = primaryProfile is not null ? 
                primaryProfile.OrganizationRelation.OrganizationId : -1;
            if (correspondsWith == CorrespondsWith.PROFILE) {
                var profile = _profileService.GetById(id)
                    .Include(p => p.OrganizationRelation)
                    .FirstOrDefault() ?? throw new EntityNotFoundException(nameof(Profile));

                return primaryOrganizationId == profile.OrganizationRelation.OrganizationId;
            } else if (correspondsWith == CorrespondsWith.GROUP) {
                var group = _groupService.GetById(id)
                    .Include(p => p.OrganizationRelation)
                    .FirstOrDefault() ?? throw new EntityNotFoundException(nameof(Profile));
                    
                return primaryOrganizationId == group.OrganizationRelation.OrganizationId;
            } else if (correspondsWith == CorrespondsWith.ORGANIZATION) {
                return primaryOrganizationId == id;
            }

            return true;
        }

        public void UseOptions(VerificationOptions options)
        {
            _permissions = _permissionService.GetProfilePermissions(options);
            _options = options;
        }
    }
}
