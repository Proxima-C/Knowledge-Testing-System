using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedTests(modelBuilder);

            SeedTestsQuestions(modelBuilder);

            SeedTestAnswers(modelBuilder);

            SeedTestStatistics(modelBuilder);

            SeedUsers(modelBuilder);

            SeedUserProfiles(modelBuilder);
        }

        private static void SeedTests(ModelBuilder modelBuilder)
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
        }

        private static void SeedTestsQuestions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestQuestion>().HasData(
                new TestQuestion
                {
                    Id = 1,
                    Text = "Question 1",
                    TestId = 1
                }
            );
        }

        private static void SeedTestAnswers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestAnswer>().HasData(
                new TestAnswer
                {
                    Id = 1,
                    Text = "Answer 1",
                    IsCorrect = true,
                    TestQuestionId = 1
                }
            );
        }

        private static void SeedTestStatistics(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestStatistics>().HasData(
                new TestStatistics
                {
                    Id = 1,
                    UserScore = 100,
                    PassingTime = new TimeSpan(1, 40, 57),
                    IsPassed = true,
                    TestId = 1,
                    UserId = 1
                }
            );
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin@gmail.com",
                }
            );
        }

        private static void SeedUserProfiles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().HasData(
                new UserProfile
                {
                    UserId = 1,
                }
            );
        }
    }
}
