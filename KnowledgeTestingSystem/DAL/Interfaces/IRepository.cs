using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        
        Task<IEnumerable<TEntity>> GetAllAsync();

        TEntity GetById(int id);

        Task<TEntity> GetByIdAsync(int id);

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void DeleteById(int id);

        Task DeleteByIdAsync(int id);

        void Update(TEntity entity);
    }
}
