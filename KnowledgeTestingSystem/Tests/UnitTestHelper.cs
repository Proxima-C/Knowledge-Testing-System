using AutoMapper;
using BLL.Mapper;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Tests
{
    internal static class UnitTestHelper
    {
        public static DbContextOptions<ApplicationContext> GetUnitTestDbOptions()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new ApplicationContext(options))
            {
                SeedData(context);
            }
            return options;
        }

        private static void SeedData(ApplicationContext context)
        {
            context.Tests.RemoveRange(context.Tests);
            context.Tests.Add(new Test { Id = 1, Title = "Test 1", Description = "test 1 description", TestDuration = 90 });
            context.Tests.Add(new Test { Id = 2, Title = "Test 2", Description = "test 2 description", TestDuration = 120 });
            context.Tests.Add(new Test { Id = 3, Title = "Test 3", Description = "test 3 description", TestDuration = 60 });

            context.UserProfiles.RemoveRange(context.UserProfiles);
            context.UserProfiles.Add(new UserProfile { Id = 1, UserName = "user1", Name = "Name" });
            context.UserProfiles.Add(new UserProfile { Id = 2, UserName = "user2", Name = "Name" });
            context.UserProfiles.Add(new UserProfile { Id = 3, UserName = "user3", Name = "Name" });

            context.SaveChanges();
        }

        public static Mapper CreateMapperProfile()
        {
            var myProfile = new AutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            return new Mapper(configuration);
        }
    }
}
