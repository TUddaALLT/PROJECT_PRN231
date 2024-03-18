using PROJECT_PRN231.Models;
using PROJECT_PRN231.Models.ViewModel;

namespace PROJECT_PRN231.Interface
{
    public interface IUserExamResultRepository
    {
        List<UserExamResultVM> GetAll();
        UserExamResult GetById(int id);
        List<UserExamResultVM> GetByUserId(int userId);
        bool UpdateUserExamResult(UserExamResult userExamResult);
        bool DeleteUserExamResult(int id);
        bool AddUserExamResult(UserExamResult userExamResult);
        bool Save();
    }
}
