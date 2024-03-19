using PROJECT_PRN231.Models.ViewModel;
using PROJECT_PRN231.Models;

namespace PROJECT_PRN231.Interface
{
    public interface IUserExamQuestionAnswerRepository
    {
        List<UserExamQuestionAnswerVM> GetAll();
        UserExamQuestionAnswer GetById(int id);
        List<UserExamQuestionAnswerVM> GetAllUserAnswerInExam(int userId, int examId);
        UserExamQuestionAnswer IsQuestionAnswered (int questionId, int examId, int userId);
        bool UpdateUserExamQuestionAnswer(UserExamQuestionAnswer userExamQuestionAnswer);
        bool DeleteUserExamQuestionAnswer(int id);
        bool AddUserExamQuestionAnswer(UserExamQuestionAnswer userExamQuestionAnswer);
        bool Save();
    }
}
