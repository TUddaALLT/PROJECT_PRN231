using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECT_PRN231.Interface;
using PROJECT_PRN231.Models.ViewModel;
using PROJECT_PRN231.Models;
using PROJECT_PRN231.Repository;

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
                    return NotFound();
                }
                return Ok(find);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost]
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
        [HttpPut("id")]
        public ActionResult Update(int id, ExamQuestion examQuestion)
        {
            if (id != examQuestion.ExamQuestionId)
            {
                return NotFound();
            }
            try
            {
                ExamQuestionRepository.Update(examQuestion);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                ExamQuestionRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
