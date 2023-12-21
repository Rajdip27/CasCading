using System.Linq.Expressions;
using AutoMapper;
using CasCading.ApplicationDb;
using Microsoft.EntityFrameworkCore;

namespace CasCading.Service
{
    public class RepositoryService<TEntity, IModel> : IRepositoryService<TEntity, IModel>
        where TEntity : class, new()
        where IModel : class
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        public RepositoryService(IMapper mapper, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            DbSet = _dbContext.Set<TEntity>();
        }
        public DbSet<TEntity> DbSet { get; }
        public async Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await DbSet.ToListAsync(cancellationToken);
            if (entities == null) return null;
            var data = _mapper.Map<IEnumerable<IModel>>(entities);
            return data;
        }

        public async Task<List<IModel>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = includes.Aggregate(_dbContext.Set<TEntity>().AsQueryable(),
                (current, include) => current.Include(include));

            var entities = await query.ToListAsync().ConfigureAwait(false);

            return _mapper.Map<List<IModel>>(entities);
        }

        public async Task<IModel> InsertAsync(IModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<IModel, TEntity>(model);
            DbSet.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            var insertedModel = _mapper.Map<TEntity, IModel>(entity);
            return insertedModel;
        }

        public async Task<IModel> UpdateAsync(int id, IModel model, CancellationToken cancellationToken)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            _mapper.Map(model, entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            var updatedModel = _mapper.Map<TEntity, IModel>(entity);
            return updatedModel;
        }
        public async Task<IModel> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            DbSet.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var deletedModel = _mapper.Map<TEntity, IModel>(entity);
            return deletedModel;
        }

        public async Task<IModel> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            var model = _mapper.Map<TEntity, IModel>(entity);
            return model;
        }
    }
}
