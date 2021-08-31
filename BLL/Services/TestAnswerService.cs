﻿using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Validation;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TestAnswerService : ITestAnswerService
    {
        readonly IUnitOfWork database;
        readonly IMapper automapper;

        public TestAnswerService(IUnitOfWork uow, IMapper mapper)
        {
            this.database = uow;
            this.automapper = mapper;
        }

        public async Task AddAsync(TestAnswerDTO model)
        {
            if (model == null)
            {
                throw new TestingSystemException("Test answer was not found");
            }

            TestAnswer answer = automapper.Map<TestAnswer>(model);

            await database.TestAnswerRepository.AddAsync(answer);
            await database.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            TestAnswer answer = await database.TestAnswerRepository.GetByIdAsync(modelId);

            if (answer == null)
            {
                throw new TestingSystemException("Test answer was not found");
            }

            await database.TestAnswerRepository.DeleteByIdAsync(modelId);
            await database.SaveAsync();
        }

        public IEnumerable<TestAnswerDTO> GetAll()
        {
            IQueryable<TestAnswer> tests = database.TestAnswerRepository.GetAll();
            return automapper.Map<IQueryable<TestAnswer>, IEnumerable<TestAnswerDTO>>(tests);
        }

        public async Task<TestAnswerDTO> GetByIdAsync(int id)
        {
            TestAnswer answer = await database.TestAnswerRepository.GetByIdAsync(id);

            if (answer == null)
            {
                throw new TestingSystemException("Test answer was not found");
            }

            TestAnswerDTO testModel = automapper.Map<TestAnswerDTO>(answer);
            return testModel;
        }

        public async Task UpdateAsync(TestAnswerDTO model)
        {
            if (model == null)
            {
                throw new TestingSystemException("Test answer was not found");
            }

            TestAnswer answer = automapper.Map<TestAnswer>(model);
            database.TestAnswerRepository.Update(answer);
            await database.SaveAsync();
        }
    }
}