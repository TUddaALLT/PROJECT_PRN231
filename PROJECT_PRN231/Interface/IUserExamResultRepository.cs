using PROJECT_PRN231.Models;
using PROJECT_PRN231.Models.ViewModel;

namespace PROJECT_PRN231.Interface
{
    public interface IUserExamResultRepository
    {
        List<UserExamResult> GetAll();
        UserExamResult GetById(int id);
        UserExamResult Create(UserExamResultVM userExamResultVM);
        void Update(UserExamResult userExamResult);
        void Delete(int id);
    }
}
