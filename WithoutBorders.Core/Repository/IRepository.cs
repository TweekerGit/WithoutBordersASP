using System.Collections.Generic;
using System.Threading.Tasks;

namespace WithoutBorders.Core.Repository
{
    public interface IRepository <TKey, TEntity>
    {
        // void Create(TEntity entity);
        // void Update(TEntity entity);
        // void Delete(TKey entityKey);
        // void Delete(TEntity entity);
        //
        // Task SaveAsync();
        Task<IEnumerable<TEntity>> GetAllAsync();
        // Task<IEnumerable<TEntity>> GetByIdAsync(TKey entityKey);
    }
}