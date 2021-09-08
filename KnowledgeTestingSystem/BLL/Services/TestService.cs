using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Validation;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TestService : ITestService
    {
        readonly IUnitOfWork database;
        readonly IMapper automapper;

        public TestService(IUnitOfWork uow, IMapper mapper)
        {
            this.database = uow;
            this.automapper = mapper;
        }

        public async Task AddAsync(TestDTO model)
        {
            if (model == null)
            {
                throw new TestingSystemException("Test can not be null");
            }

            if (model.Title == null || model.Description == null || model.TestDuration.TotalMinutes == 0 || model.TestQuestionsIds == null)
            {
                throw new TestingSystemException("Test has incorrect data");
            }

            Test test = automapper.Map<Test>(model);

            await database.TestRepository.AddAsync(test);
            await database.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            Test test = await database.TestRepository.GetByIdAsync(modelId);

            if (test == null)
            {
                throw new TestingSystemException("Test was not found");
            }

            await database.TestRepository.DeleteByIdAsync(modelId);
            await database.SaveAsync();
        }

        public async Task<IEnumerable<TestDTO>> GetAll()
        {
            IEnumerable<Test> tests = await database.TestRepository.GetAllAsync();
            return automapper.Map<IEnumerable<Test>, IEnumerable<TestDTO>>(tests);
        }

        public async Task<TestDTO> GetByIdAsync(int id)
        {
            Test test = await database.TestRepository.GetByIdAsync(id);

            if (test == null)
            {
                throw new TestingSystemException("Test was not found");
            }

            TestDTO testModel = automapper.Map<TestDTO>(test);
            return testModel;
        }

        public async Task UpdateAsync(TestDTO model)
        {
            if (model == null)
            {
                throw new TestingSystemException("Test can not be null");
            }

            if (model.Title == null || model.Description == null || model.TestDuration.TotalMinutes == 0 || model.TestQuestionsIds == null)
            {
                throw new TestingSystemException("Test has incorrect data");
            }

            Test test = automapper.Map<Test>(model);
            database.TestRepository.Update(test);
            await database.SaveAsync();
        }
    }
}
