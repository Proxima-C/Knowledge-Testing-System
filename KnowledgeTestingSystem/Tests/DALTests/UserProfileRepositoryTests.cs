using DAL.Data;
using DAL.Entities;
using DAL.Repositories;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.DALTests
{
    [TestFixture]
    public class UserProfileRepositoryTests
    {
        [Test]
        public async Task UserProfileRepository_GetAll_ReturnsAllValues()
        {
            using (var context = new ApplicationContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var userProfileRepository = new UserProfileRepository(context);

                var userProfiles = await userProfileRepository.GetAllAsync();

                Assert.AreEqual(3, userProfiles.Count());
            }
        }

        [Test]
        public async Task UserProfileRepository_GetById_ReturnsSingleValue()
        {
            using (var context = new ApplicationContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var userProfileRepository = new UserProfileRepository(context);

                var userProfile = await userProfileRepository.GetByIdAsync(1);

                Assert.AreEqual(1, userProfile.Id);
                Assert.AreEqual("user1", userProfile.UserName);
                Assert.AreEqual("Name", userProfile.Name);
            }
        }

        [Test]
        public async Task UserProfileRepository_AddAsync_AddsValueToDatabase()
        {
            using (var context = new ApplicationContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var userProfileRepository = new UserProfileRepository(context);
                var userProfile = new UserProfile() { Id = 4, UserName = "user4", Name = "Name" };

                await userProfileRepository.AddAsync(userProfile);
                await context.SaveChangesAsync();

                Assert.AreEqual(4, context.UserProfiles.Count());
            }
        }

        [Test]
        public async Task UserProfileRepository_DeleteByIdAsync_DeletesEntity()
        {
            using (var context = new ApplicationContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var userProfileRepository = new UserProfileRepository(context);

                await userProfileRepository.DeleteByIdAsync(1);
                await context.SaveChangesAsync();

                Assert.AreEqual(2, context.UserProfiles.Count());
            }
        }

        [Test]
        public async Task UserProfileRepository_Update_UpdatesEntity()
        {
            using (var context = new ApplicationContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var userProfileRepository = new UserProfileRepository(context);

                var newUserName = "updated_user1";
                var newName = "UpdatedName";
                var userProfile = new UserProfile() { Id = 1, UserName = newUserName, Name = newName };

                userProfileRepository.Update(userProfile);
                await context.SaveChangesAsync();

                Assert.AreEqual(1, userProfile.Id);
                Assert.AreEqual(newUserName, userProfile.UserName);
                Assert.AreEqual(newName, userProfile.Name);
            }
        }
    }
}
