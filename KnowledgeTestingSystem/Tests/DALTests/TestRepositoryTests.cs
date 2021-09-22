using DAL.Data;
using DAL.Entities;
using DAL.Repositories;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.DALTests
{
    [TestFixture]
    public class TestRepositoryTests
    {
        [Test]
        public async Task TestRepository_GetAll_ReturnsAllValues()
        {
            using (var context = new ApplicationContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var testRepository = new TestRepository(context);

                var tests = await testRepository.GetAllAsync();

                Assert.AreEqual(3, tests.Count());
            }
        }

        [Test]
        public async Task TestRepository_GetById_ReturnsSingleValue()
        {
            using (var context = new ApplicationContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var testRepository = new TestRepository(context);

                var test = await testRepository.GetByIdAsync(1);

                Assert.AreEqual(1, test.Id);
                Assert.AreEqual("Test 1", test.Title);
                Assert.AreEqual("test 1 description", test.Description);
                Assert.AreEqual(90, test.TestDuration);
            }
        }

        [Test]
        public async Task TestRepository_AddAsync_AddsValueToDatabase()
        {
            using (var context = new ApplicationContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var testRepository = new TestRepository(context);
                var test = new Test() { Id = 4, Title = "Test 3", Description = "test 3 description", TestDuration = 60 };

                await testRepository.AddAsync(test);
                await context.SaveChangesAsync();

                Assert.AreEqual(4, context.Tests.Count());
            }
        }

        [Test]
        public async Task TestRepository_DeleteByIdAsync_DeletesEntity()
        {
            using (var context = new ApplicationContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var testRepository = new TestRepository(context);

                await testRepository.DeleteByIdAsync(1);
                await context.SaveChangesAsync();

                Assert.AreEqual(2, context.Tests.Count());
            }
        }

        [Test]
        public async Task TestRepository_Update_UpdatesEntity()
        {
            using (var context = new ApplicationContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var testRepository = new TestRepository(context);

                var newTitle = "Updated Test 1";
                var newDescription = "updated test 1 desription";
                var newTestDuration = 120;
                var test = new Test() { Id = 1, Title = newTitle, Description = newDescription, TestDuration = newTestDuration };

                testRepository.Update(test);
                await context.SaveChangesAsync();

                Assert.AreEqual(1, test.Id);
                Assert.AreEqual(newTitle, test.Title);
                Assert.AreEqual(newDescription, test.Description);
                Assert.AreEqual(newTestDuration, test.TestDuration);
            }
        }
    }
}
