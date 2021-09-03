using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().HasData(
                new Test
                {
                    Id = 1,
                    Title = "Test 1",
                    Description = "Test description",
                    TestDuration = new TimeSpan(2, 0, 0)
                }
            );

            modelBuilder.Entity<TestQuestion>().HasData(
                new TestQuestion
                {
                    Id = 1,
                    Text = "Test 1",
                    TestId = 1
                }
            );

            modelBuilder.Entity<TestAnswer>().HasData(
                new TestAnswer
                {
                    Id = 1,
                    IsCorrect = true,
                    TestQuestionId = 1
                }
            );

            //modelBuilder.Entity<TestStatistics>().HasData(
            //    new TestStatistics
            //    {
            //        Id = 1,
            //        UserScore = 100,
            //        PassingTime = new TimeSpan(2, 10, 57),
            //        IsPassed = true,
            //        TestId = 1,
            //        UserId = 1
            //    }
            //);
        }
    }
}
