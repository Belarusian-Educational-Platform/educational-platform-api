
using api.EntityFramework.Contexts;
using api.Exceptions.RepositoryExceptions;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace ProfileAuthorization
{
    public class VerificationOptionsService : IVerificationOptionsService,
        IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;

        public VerificationOptionsService(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public bool CheckOrganizationСorrespondence(VerificationOptions options)
        {
            var profile = _dbContext.Profiles
                .Include(p => p.OrganizationRelation)
                .FirstOrDefault(p => p.Id == options.ProfileId);

            if (profile is null)
            {
                throw new EntityNotFoundException(nameof(Profile));
            }

            int organizationId = profile.OrganizationRelation.OrganizationId;

            if (options.VerificationLevels.Contains(PermissionLevel.PROFILE_GROUP))
            {
                var group = _dbContext.Groups
                    .Include(g => g.OrganizationRelation)
                    .FirstOrDefault(g => g.Id == options.GroupId);
                if (group is null)
                {
                    throw new EntityNotFoundException(nameof(Group));
                }
                if (group.OrganizationRelation.OrganizationId != organizationId)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
