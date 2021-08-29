using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TestRepository : ITestRepository
    {
        readonly ApplicationContext _context;
        readonly DbSet<Test> _dbSet;

        public TestRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<Test>();
        }

        public void Add(Test entity)
        {
            if (entity != null)
            {
                _dbSet.Add(entity);
            }
        }

        public async Task AddAsync(Test entity)
        {
            if (entity != null)
            {
                await _dbSet.AddAsync(entity);
            }
        }

        public void DeleteById(int id)
        {
            Test entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            Test entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public IQueryable<Test> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public Test GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<Test> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(Test entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
