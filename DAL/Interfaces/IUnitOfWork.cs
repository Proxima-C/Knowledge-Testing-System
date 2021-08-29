using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ITestRepository TestRepository { get; }

        ITestQuestionRepository TestQuestionRepository { get; }

        ITestAnswerRepository TestAnswerRepository { get; }

        Task SaveAsync();
    }
}
