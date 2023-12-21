using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CasCading.Service
{
    public interface IRepositoryService<TEntity, IModel>
        where TEntity : class,new ()
    where IModel : class
    {
        Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<IModel>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<IModel> InsertAsync(IModel model, CancellationToken cancellationToken);
        Task<IModel> UpdateAsync(int id, IModel model, CancellationToken cancellationToken);
        Task<IModel> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<IModel> GetByIdAsync(int id, CancellationToken cancellationToken);

    }
}
