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
    public class TestStatisticsService : ITestStatisticsService
    {
        readonly IUnitOfWork database;
        readonly IMapper automapper;

        public TestStatisticsService(IUnitOfWork uow, IMapper mapper)
        {
            this.database = uow;
            this.automapper = mapper;
        }

        public async Task AddAsync(TestStatisticsDTO model)
        {
            if (model == null)
            {
                throw new TestingSystemException("Test statistics was not found");
            }

            TestStatistics statistics = automapper.Map<TestStatistics>(model);

            await database.TestStatisticsRepository.AddAsync(statistics);
            await database.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            TestStatistics statistics = await database.TestStatisticsRepository.GetByIdAsync(modelId);

            if (statistics == null)
            {
                throw new TestingSystemException("Test statistics was not found");
            }

            await database.TestStatisticsRepository.DeleteByIdAsync(modelId);
            await database.SaveAsync();
        }

        public IEnumerable<TestStatisticsDTO> GetAll()
        {
            IQueryable<TestStatistics> tests = database.TestStatisticsRepository.GetAll();
            return automapper.Map<IQueryable<TestStatistics>, IEnumerable<TestStatisticsDTO>>(tests);
        }

        public async Task<TestStatisticsDTO> GetByIdAsync(int id)
        {
            TestStatistics statistics = await database.TestStatisticsRepository.GetByIdAsync(id);

            if (statistics == null)
            {
                throw new TestingSystemException("Test statistics was not found");
            }

            TestStatisticsDTO testModel = automapper.Map<TestStatisticsDTO>(statistics);
            return testModel;
        }

        public async Task UpdateAsync(TestStatisticsDTO model)
        {
            if (model == null)
            {
                throw new TestingSystemException("Test statistics was not found");
            }

            TestStatistics statistics = automapper.Map<TestStatistics>(model);
            database.TestStatisticsRepository.Update(statistics);
            await database.SaveAsync();
        }
    }
}
