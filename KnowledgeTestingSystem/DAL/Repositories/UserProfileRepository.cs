using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        readonly ApplicationContext _context;
        readonly DbSet<UserProfile> _dbSet;

        public UserProfileRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<UserProfile>();
        }

        public void Add(UserProfile entity)
        {
            if (entity != null)
            {
                _dbSet.Add(entity);
            }
        }

        public async Task AddAsync(UserProfile entity)
        {
            if (entity != null)
            {
                await _dbSet.AddAsync(entity);
            }
        }

        public void DeleteById(int id)
        {
            UserProfile entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            UserProfile entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public UserProfile GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<UserProfile> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(UserProfile entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
