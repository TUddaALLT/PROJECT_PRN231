using PROJECT_PRN231.Models.ViewModel;
using PROJECT_PRN231.Models;

namespace PROJECT_PRN231.Interface
{
    public interface IAnswerRepository
    {
        List<Answer> GetAll();
        Answer GetById(int id);
        Answer Create(AnswerVM answerVM);
        void Update(Answer answerVM);
        void Delete(int id);
    }
}
