using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly ApplicationContext _context;
        readonly DbSet<User> _dbSet;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        public void Add(User entity)
        {
            if (entity != null)
            {
                _dbSet.Add(entity);
            }
        }

        public async Task AddAsync(User entity)
        {
            if (entity != null)
            {
                await _dbSet.AddAsync(entity);
            }
        }

        public void DeleteById(int id)
        {
            User entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            User entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public User GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
