using api.Exceptions.RepositoryExceptions;
using api.Models;
using api.Models.Base;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ProfileAuthorization
{
    public class VerificationService : IVerificationService
    {
        private readonly IPermissionService _permissionService;
        private readonly IProfileService _profileService;

        private PermissionSet _permissions = new();
        private VerificationOptions _options = new();

        public VerificationService(IPermissionService permissionService,
            IProfileService profileService)
        {
            _permissionService = permissionService;
            _profileService = profileService;
        }

        public bool Assert(params Permission[] requirements)
        {
            foreach (var requirement in requirements)
            {
                if (!_permissions.HasPermission(requirement))
                {
                    return false;
                }
            }

            return true;
        }

        public bool RequireEntityCorrespondence<T>(int id)
        {
            Type entityType = typeof(T);
            if (entityType == typeof(Profile))
            {
                return id == _options.ProfileId;
            }
            else if (entityType == typeof(Group))
            {
                return id == _options.GroupId;
            }
            else if (entityType == typeof(Organization))
            {
                return id == _options.OrganizationId;
            }

            return false;
        }

        public bool RequireOrganizationCorrespondence<CorrespondsWith>(int id)
        {
            Type correspondsWith = typeof(CorrespondsWith);

            var primaryOrganization = _profileService.GetById(_options.ProfileId)
                .Include(p => p.OrganizationRelation)
                    .ThenInclude(por => por.Organization)
                        .ThenInclude(o => o.GroupRelations)
                .Include(p => p.OrganizationRelation)
                    .ThenInclude(por => por.Organization)
                        .ThenInclude(o => o.ProfileRelations)
                .Select(x => x.OrganizationRelation.Organization);
            
            if (!primaryOrganization.Any()) {
                return false;
            }

            if (correspondsWith == typeof(Profile))
            {
                return primaryOrganization.Any(
                    o => o.ProfileRelations.Any(por => por.ProfileId == id)
                );
            }
            else if (correspondsWith == typeof(Group))
            {
                return primaryOrganization.Any(
                    o => o.GroupRelations.Any(gor => gor.GroupId == id)
                );
            }
            else if (correspondsWith == typeof(Organization))
            {
                return primaryOrganization.Any(
                    o => o.Id == id
                );
            }

            return false;
        }

        public async Task UseOptions(VerificationOptions options)
        {
            _permissions = await _permissionService.GetProfilePermissions(options);
            _options = options;
        }
    }
}
