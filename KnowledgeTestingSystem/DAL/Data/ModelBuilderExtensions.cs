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
                    TestDuration = 90,
                },
                new Test
                {
                    Id = 2,
                    Title = "Test 2",
                    Description = "Test description",
                    TestDuration = 60,
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
                },
                new TestQuestion
                {
                    Id = 2,
                    Text = "Question 2",
                    TestId = 1
                },
                new TestQuestion
                {
                    Id = 3,
                    Text = "Question 3",
                    TestId = 1
                },
                new TestQuestion
                {
                    Id = 4,
                    Text = "Question 1",
                    TestId = 2
                },
                new TestQuestion
                {
                    Id = 5,
                    Text = "Question 2",
                    TestId = 2
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
                },
                new TestAnswer
                {
                    Id = 2,
                    Text = "Answer 2",
                    IsCorrect = false,
                    TestQuestionId = 1
                },
                new TestAnswer
                {
                    Id = 3,
                    Text = "Answer 1",
                    IsCorrect = false,
                    TestQuestionId = 2
                },
                new TestAnswer
                {
                    Id = 4,
                    Text = "Answer 2",
                    IsCorrect = true,
                    TestQuestionId = 2
                },
                new TestAnswer
                {
                    Id = 5,
                    Text = "Answer 1",
                    IsCorrect = true,
                    TestQuestionId = 3
                },
                new TestAnswer
                {
                    Id = 6,
                    Text = "Answer 2",
                    IsCorrect = false,
                    TestQuestionId = 3
                },
                new TestAnswer
                {
                    Id = 7,
                    Text = "Answer 1",
                    IsCorrect = true,
                    TestQuestionId = 4
                },
                new TestAnswer
                {
                    Id = 8,
                    Text = "Answer 2",
                    IsCorrect = false,
                    TestQuestionId = 4
                },
                new TestAnswer
                {
                    Id = 9,
                    Text = "Answer 1",
                    IsCorrect = true,
                    TestQuestionId = 5
                },
                new TestAnswer
                {
                    Id = 10,
                    Text = "Answer 2",
                    IsCorrect = false,
                    TestQuestionId = 5
                }
            );
        }

        private static void SeedTestStatistics(ModelBuilder modelBuilder)
        {
            DateTime startDate = DateTime.Now;
            modelBuilder.Entity<TestStatistics>().HasData(
                new TestStatistics
                {
                    Id = 1,
                    UserScore = 100,
                    StartDate = startDate,
                    EndDate = startDate.AddMinutes(30),
                    IsPassed = true,
                    TestId = 1,
                    UserProfileId = 1
                },
                new TestStatistics
                {
                    Id = 2,
                    UserScore = 100,
                    StartDate = startDate,
                    EndDate = startDate.AddMinutes(30),
                    IsPassed = true,
                    TestId = 1,
                    UserProfileId = 1
                },
                new TestStatistics
                {
                    Id = 3,
                    UserScore = 90,
                    StartDate = startDate,
                    EndDate = startDate.AddMinutes(80),
                    IsPassed = true,
                    TestId = 1,
                    UserProfileId = 2
                },
                new TestStatistics
                {
                    Id = 4,
                    UserScore = 50,
                    StartDate = startDate,
                    EndDate = startDate.AddMinutes(20),
                    IsPassed = false,
                    TestId = 2,
                    UserProfileId = 2
                },
                new TestStatistics
                {
                    Id = 5,
                    UserScore = 100,
                    StartDate = startDate,
                    EndDate = startDate.AddMinutes(55),
                    IsPassed = true,
                    TestId = 2,
                    UserProfileId = 2
                }
            );
        }

        private static void SeedUserProfiles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().HasData(
                new UserProfile
                {
                    Id = 1,
                    UserName = "admin",
                    Name = "admin",
                    Age = 100,
                },
                new UserProfile
                {
                    Id = 2,
                    UserName = "user",
                    Name = "user's name",
                    Age = 30,
                },
                new UserProfile
                {
                    Id = 3,
                    UserName = "moderator",
                    Name = "moderator's name",
                    Age = 25,
                }
            );
        }
    }
}
