using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class TestAnswerRepository : ITestAnswerRepository
    {
        readonly ApplicationContext _context;
        readonly DbSet<TestAnswer> _dbSet;

        public TestAnswerRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TestAnswer>();
        }

        public void Add(TestAnswer entity)
        {
            if (entity != null)
            {
                _dbSet.Add(entity);
            }
        }

        public async Task AddAsync(TestAnswer entity)
        {
            if (entity != null)
            {
                await _dbSet.AddAsync(entity);
            }
        }

        public void DeleteById(int id)
        {
            TestAnswer entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            TestAnswer entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public IEnumerable<TestAnswer> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<TestAnswer>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public TestAnswer GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TestAnswer> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(TestAnswer entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
