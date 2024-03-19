using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECT_PRN231.Interface;
using PROJECT_PRN231.Models;
using PROJECT_PRN231.Models.ViewModel;
using PROJECT_PRN231.Repository;

namespace PROJECT_PRN231.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExamResultController : ControllerBase
    {
        private readonly IUserExamResultRepository _userExamResultRepository;
        private readonly IUserExamQuestionAnswerRepository _userExamQuestionAnswerRepository;
        private readonly IExamRepository _examRepository;
        public UserExamResultController(IUserExamResultRepository userExamResultRepository,
            IUserExamQuestionAnswerRepository userExamQuestionAnswerRepository,
            IExamRepository examRepository)
        {
            _userExamResultRepository = userExamResultRepository;
            _userExamQuestionAnswerRepository = userExamQuestionAnswerRepository;
            _examRepository = examRepository;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _userExamResultRepository.GetAll();
            if (list == null)
            {
                return NotFound("There is no result");
            }
            return Ok(list);

        }

        //[Authorize(Roles = "Admin,User")]
        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _userExamResultRepository.GetById(id);
            if (result == null)
            {
                return NotFound($"No result with id {id}");
            }
            return Ok(result);
        }

        //[Authorize(Roles = "Admin,User")]
        [HttpGet("userId/{userId}")]
        public IActionResult GetByUser(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var list = _userExamResultRepository.GetByUserId(userId);
            if (list == null)
            {
                return NotFound($"User with id {userId} have no result");
            }
            return Ok(list);
        }

        //[Authorize(Roles = "Admin,User")]
        [HttpPost]
        public IActionResult Create([FromBody] UserExamResultVM userExamResultVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userExamResult = new UserExamResult
            {
                UserId = userExamResultVM.UserId,
                ExamId = userExamResultVM.ExamId,
                Score = userExamResultVM.Score,
                StartTime = userExamResultVM.StartTime,
                EndTime = userExamResultVM.EndTime
            };
            if (_userExamResultRepository.AddUserExamResult(userExamResult))
            {
                return Ok("Result added");
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong while creating new record");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //[Authorize(Roles = "Admin,User")]
        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userExamResult = _userExamResultRepository.GetById(id);
            if (userExamResult == null)
            {
                return NotFound($"Result with {id} not found");
            }
            var examAnswers = _userExamQuestionAnswerRepository.GetAllUserAnswerInExam(userExamResult.UserId.Value, userExamResult.ExamId.Value);
            var correctAnswers = examAnswers.Where(x => x.IsCorrect == true).Count();
            var answersCount = _examRepository.GetQuestionCount(userExamResult.ExamId.Value);
            userExamResult.Score = (10 / answersCount) * correctAnswers;
            userExamResult.EndTime = DateTime.Now;
            if (_userExamResultRepository.UpdateUserExamResult(userExamResult))
            {
                return Ok($"Result updated score: {userExamResult.Score}");
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong while updating record");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var find = _userExamResultRepository.GetById(id);
            if (find == null)
            {
                return NotFound("Not found!");
            }
            if (_userExamResultRepository.DeleteUserExamResult(id))
            {
                return Ok("Result deleted");
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong while deleting new record");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
