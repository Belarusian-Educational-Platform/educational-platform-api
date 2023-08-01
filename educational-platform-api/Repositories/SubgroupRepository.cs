using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace educational_platform_api.Repositories
{
    public class SubgroupRepository : ISubgroupRepository
    {
        private readonly MySQLContext _dbContext;

        public SubgroupRepository(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Subgroup Create(Subgroup subgroup)
        {
            Subgroup subgroupEntity;
            try
            {
                subgroupEntity = _dbContext.Subgroups.Add(subgroup).Entity;
            } catch (Exception ex)
            {
                throw new EntityCreateException(nameof(Subgroup), ex.Message, ex);
            }
            return subgroupEntity;
        }

        public void Delete(params Subgroup[] subgroups)
        {
            try
            {
                _dbContext.Subgroups.RemoveRange(subgroups);
            } catch (Exception ex)
            {
                throw new EntityDeleteException(nameof(Subgroup), ex.Message, ex);
            }
        }

        public IEnumerable<Subgroup> GetAll()
        {
            return _dbContext.Subgroups.ToList();
        }

        public IEnumerable<Subgroup> GetByGroupId(int groupId)
        {
           List<Subgroup> subgroups = _dbContext.Subgroups
                .Where(x => x.GroupId == groupId)
                .ToList();

            return subgroups;
        }

        public Subgroup GetById(int id)
        {
            Subgroup subgroup;
            try
            {
                subgroup = _dbContext.Subgroups.First(x => x.Id == id);
            } catch (Exception ex)
            {
                throw new EntityNotFoundException(nameof(Subgroup), ex.Message, ex);
            }

            return subgroup;
        }

        public IEnumerable<Subgroup> GetByProfileId(int profileId)
        {
            List<Subgroup> subgroups = _dbContext.Subgroups
                .Join(_dbContext.ProfileSubgroupRelations.Where(psr => psr.ProfileId == profileId), 
                    s => s.Id, 
                    psr => psr.SubgroupId, 
                    (s, psr) => s)
                .ToList();

            return subgroups;
        }

        public void Update(Subgroup subgroup)
        {
            try
            {
                _dbContext.Subgroups.Attach(subgroup);
                _dbContext.Entry(subgroup).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new EntityUpdateException(nameof(Subgroup), ex.Message, ex);
            }
        }
    }
}
