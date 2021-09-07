﻿using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationContext _context;

        private ITestRepository testRepository;
        private ITestQuestionRepository testQuestionRepository;
        private ITestAnswerRepository testAnswerRepository;
        private ITestStatisticsRepository testStatisticsRepository;
        private IUserRepository userRepository;

        public UnitOfWork(DbContextOptions<ApplicationContext> options)
        {
            _context = new ApplicationContext(options);
        }

        public ITestRepository TestRepository
        {
            get
            {
                if (this.testRepository == null)
                {
                    this.testRepository = new TestRepository(_context);
                }
                return testRepository;
            }
        }

        public ITestQuestionRepository TestQuestionRepository
        {
            get
            {
                if (this.testQuestionRepository == null)
                {
                    this.testQuestionRepository = new TestQuestionRepository(_context);
                }
                return testQuestionRepository;
            }
        }

        public ITestAnswerRepository TestAnswerRepository
        {
            get
            {
                if (this.testAnswerRepository == null)
                {
                    this.testAnswerRepository = new TestAnswerRepository(_context);
                }
                return testAnswerRepository;
            }
        }

        public ITestStatisticsRepository TestStatisticsRepository
        {
            get
            {
                if (this.testStatisticsRepository == null)
                {
                    this.testStatisticsRepository = new TestStatisticsRepository(_context);
                }
                return testStatisticsRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(_context);
                }
                return userRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
