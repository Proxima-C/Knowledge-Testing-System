using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using System.Linq;

namespace BLL.Mapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Test, TestDTO>()
                .ForMember(dest => dest.TestQuestionsIds, opt => opt.MapFrom(src => src.TestQuestions.Select(e => e.Id)))
                .ReverseMap();

            CreateMap<TestQuestion, TestQuestionDTO>()
                .ForMember(dest => dest.TestQuestionAnswersIds, opt => opt.MapFrom(src => src.TestQuestionAnswers.Select(e => e.Id)))
                .ReverseMap();

            CreateMap<TestAnswer, TestAnswerDTO>()
                .ReverseMap();

            CreateMap<TestStatistics, TestStatisticsDTO>()
                .ReverseMap();
        }
    }
}
