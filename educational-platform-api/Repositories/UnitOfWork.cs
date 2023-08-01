using educational_platform_api.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace educational_platform_api.Repositories
{
    public class UnitOfWork : IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;
        private IProfileRepository profileRepository;
        private IOrganizationRepository organizationRepository;
        private IGroupRepository groupRepository;
        private ISubgroupRepository subgroupRepository;
        private IProfileOrganizationRelationRepository profileOrganizationRelationRepository;
        private IProfileGroupRelationRepository profileGroupRelationRepository;
        private IProfileSubgroupRelationRepository profileSubgroupRelationRepository;
        private IGroupOrganizationRelationRepository groupOrganizationRelationRepository;

        public UnitOfWork(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public IProfileRepository Profiles
        {
            get
            {
                if (profileRepository == null)
                {
                    profileRepository = new ProfileRepository(_dbContext);
                } 
                return profileRepository;
            }
        }

        public IOrganizationRepository Organizations
        {
            get
            {
                if (organizationRepository == null)
                {
                    organizationRepository = new OrganizationRepository(_dbContext);
                }
                return organizationRepository;
            }
        }

        public IGroupRepository Groups
        {
            get
            {
                if (groupRepository == null)
                {
                    groupRepository = new GroupRepository(_dbContext);
                }
                return groupRepository;
            }
        }

        public ISubgroupRepository Subgroups
        {
            get
            {
                if (subgroupRepository == null)
                {
                    subgroupRepository = new SubgroupRepository(_dbContext);
                }
                return subgroupRepository;
            }
        }

        public IProfileOrganizationRelationRepository ProfileOrganizationRelations
        {
            get
            {
                if (profileOrganizationRelationRepository == null)
                {
                    profileOrganizationRelationRepository = new ProfileOrganizationRelationRepository(_dbContext);
                }
                return profileOrganizationRelationRepository;
            }
        }

        public IProfileGroupRelationRepository ProfileGroupRelations
        {
            get
            {
                if (profileGroupRelationRepository == null)
                {
                    profileGroupRelationRepository = new ProfileGroupRelationRepository(_dbContext);
                }
                return profileGroupRelationRepository;
            }
        }

        public IProfileSubgroupRelationRepository ProfileSubgroupRelations
        {
            get
            {
                if (profileSubgroupRelationRepository == null)
                {
                    profileSubgroupRelationRepository = new ProfileSubgroupRelationRepository(_dbContext);
                }
                return profileSubgroupRelationRepository;
            }
        }

        public IGroupOrganizationRelationRepository GroupOrganizationRelations
        {
            get
            {
                if (groupOrganizationRelationRepository == null)
                {
                    groupOrganizationRelationRepository = new GroupOrganizationRelationRepository(_dbContext);
                }
                return groupOrganizationRelationRepository;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }
    }
}
