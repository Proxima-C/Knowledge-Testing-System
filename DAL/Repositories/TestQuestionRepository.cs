using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class TestQuestionRepository : ITestQuestionRepository
    {
        readonly ApplicationContext _context;
        readonly DbSet<TestQuestion> _dbSet;

        public TestQuestionRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TestQuestion>();
        }

        public void Add(TestQuestion entity)
        {
            if (entity != null)
            {
                _dbSet.Add(entity);
            }
        }

        public async Task AddAsync(TestQuestion entity)
        {
            if (entity != null)
            {
                await _dbSet.AddAsync(entity);
            }
        }

        public void DeleteById(int id)
        {
            TestQuestion entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            TestQuestion entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public IQueryable<TestQuestion> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public TestQuestion GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TestQuestion> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(TestQuestion entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
