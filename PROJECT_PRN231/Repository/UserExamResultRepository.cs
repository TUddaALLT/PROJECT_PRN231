using Microsoft.EntityFrameworkCore;
using PROJECT_PRN231.Interface;
using PROJECT_PRN231.Models;
using PROJECT_PRN231.Models.ViewModel;

namespace PROJECT_PRN231.Repository
{
    public class UserExamResultRepository : IUserExamResultRepository
    {
        private ExamSystemContext _context;
        public UserExamResultRepository(ExamSystemContext context)
        {
            _context = context;
        }
        public UserExamResult Create(UserExamResultVM userExamResultVM)
        {
            var _new = new UserExamResult
            {
                UserId = userExamResultVM.UserId,
                ExamId = userExamResultVM.ExamId,
                Score = userExamResultVM.Score,
                StartTime = userExamResultVM.StartTime,
                EndTime = userExamResultVM.EndTime,
            };
            _context.Add(_new);
            _context.SaveChanges();

            return new UserExamResult
            {
                ResultId = _new.ResultId,
                UserId = userExamResultVM.UserId,
                ExamId = userExamResultVM.ExamId,
                Score = userExamResultVM.Score,
                StartTime = userExamResultVM.StartTime,
                EndTime = userExamResultVM.EndTime,
            };
        }

        public void Delete(int id)
        {
            var find = _context.UserExamResults.SingleOrDefault(f => f.ResultId == id); 
            if (find != null)
            {
                _context.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<UserExamResult> GetAll()
        {
            var list = _context.UserExamResults.ToList();
            return list;
        }

        public UserExamResult GetById(int id)
        {
            var find = _context.UserExamResults.FirstOrDefault(f => f.ResultId == id);
            if (find != null)
            {
                return new UserExamResult
                {
                    ResultId= find.ResultId,
                    UserId = find.UserId,   
                    ExamId = find.ExamId,
                    Score = find.Score,
                    StartTime = find.StartTime,
                    EndTime = find.EndTime,
                };
            }
            return null;
        }

        public void Update(UserExamResult userExamResult)
        {
            throw new NotImplementedException();
        }
    }
}
