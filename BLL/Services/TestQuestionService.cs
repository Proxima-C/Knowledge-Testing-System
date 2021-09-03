using AutoMapper;
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
    public class TestQuestionService : ITestQuestionService
    {
        readonly IUnitOfWork database;
        readonly IMapper automapper;

        public TestQuestionService(IUnitOfWork uow, IMapper mapper)
        {
            this.database = uow;
            this.automapper = mapper;
        }

        public async Task AddAsync(TestQuestionDTO model)
        {
            if (model == null)
            {
                throw new TestingSystemException("Test question was not found");
            }

            TestQuestion question = automapper.Map<TestQuestion>(model);

            await database.TestQuestionRepository.AddAsync(question);
            await database.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            TestQuestion question = await database.TestQuestionRepository.GetByIdAsync(modelId);

            if (question == null)
            {
                throw new TestingSystemException("Test question was not found");
            }

            await database.TestQuestionRepository.DeleteByIdAsync(modelId);
            await database.SaveAsync();
        }

        public IEnumerable<TestQuestionDTO> GetAll()
        {
            IQueryable<TestQuestion> tests = database.TestQuestionRepository.GetAll();
            return automapper.Map<IQueryable<TestQuestion>, IEnumerable<TestQuestionDTO>>(tests);
        }

        public async Task<TestQuestionDTO> GetByIdAsync(int id)
        {
            TestQuestion question = await database.TestQuestionRepository.GetByIdAsync(id);

            if (question == null)
            {
                throw new TestingSystemException("Test question was not found");
            }

            TestQuestionDTO testModel = automapper.Map<TestQuestionDTO>(question);
            return testModel;
        }

        public async Task UpdateAsync(TestQuestionDTO model)
        {
            if (model == null)
            {
                throw new TestingSystemException("Test question was not found");
            }

            TestQuestion question = automapper.Map<TestQuestion>(model);
            database.TestQuestionRepository.Update(question);
            await database.SaveAsync();
        }
    }
}
