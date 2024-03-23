using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECT_PRN231.Interface;
using PROJECT_PRN231.Models.ViewModel;
using PROJECT_PRN231.Models;
using PROJECT_PRN231.Repository;
using Microsoft.AspNetCore.Authorization;

namespace PROJECT_PRN231.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamQuestionController : ControllerBase
    {
        public IExamQuestionRepository ExamQuestionRepository;

        public ExamQuestionController(IExamQuestionRepository examQuestionRepository)
        {
            ExamQuestionRepository = examQuestionRepository;
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(ExamQuestionRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            try
            {
                var find = ExamQuestionRepository.GetById(id);
                if (find == null)
                {
                    return NotFound("Not found!");
                }
                return Ok(find);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        
        [HttpGet("examId/{examId}")]
        public IActionResult GetByExamId(int examId)
        {
            try
            {
                var list = ExamQuestionRepository.GetAllQuestionsOfExam(examId);
                if (list == null)
                {
                    return NotFound("not found");
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        
        [HttpPost("Add")]
        public IActionResult Create(ExamQuestionVM examQuestionVM)
        {
            try
            {
                return Ok(ExamQuestionRepository.Create(examQuestionVM));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("Update/{id}")]
        public ActionResult Update(int id, ExamQuestion examQuestion)
        {
            if (id != examQuestion.ExamQuestionId)
            {
                return NotFound("Not found!");
            }
            try
            {
                ExamQuestionRepository.Update(examQuestion);
                return Ok("Update success!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var find = ExamQuestionRepository.GetById(id);
            if (find == null)
            {
                return NotFound("Not found!");
            }
            try
            {
                ExamQuestionRepository.Delete(id);
                return Ok("Delete success");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
