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
                throw new TestingSystemException("Test statistics can not be null");
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

        public async Task<IEnumerable<TestStatisticsDTO>> GetAll()
        {
            IEnumerable<TestStatistics> statistics = await database.TestStatisticsRepository.GetAllAsync();
            return automapper.Map<IEnumerable<TestStatistics>, IEnumerable<TestStatisticsDTO>>(statistics);
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
                throw new TestingSystemException("Test statistics can not be null");
            }

            TestStatistics statistics = automapper.Map<TestStatistics>(model);
            database.TestStatisticsRepository.Update(statistics);
            await database.SaveAsync();
        }
    }
}
