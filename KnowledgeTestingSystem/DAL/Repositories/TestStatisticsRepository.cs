using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TestStatisticsRepository : ITestStatisticsRepository
    {
        readonly ApplicationContext _context;
        readonly DbSet<TestStatistics> _dbSet;

        public TestStatisticsRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TestStatistics>();
        }

        public void Add(TestStatistics entity)
        {
            if (entity != null)
            {
                _dbSet.Add(entity);
            }
        }

        public async Task AddAsync(TestStatistics entity)
        {
            if (entity != null)
            {
                await _dbSet.AddAsync(entity);
            }
        }

        public void DeleteById(int id)
        {
            TestStatistics entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            TestStatistics entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public IEnumerable<TestStatistics> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<TestStatistics>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public TestStatistics GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TestStatistics> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(TestStatistics entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
