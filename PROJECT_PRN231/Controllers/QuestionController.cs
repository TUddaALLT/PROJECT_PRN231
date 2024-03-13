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
    public class QuestionController : ControllerBase
    {
        public IQuestionRepository QuestionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            QuestionRepository = questionRepository;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(QuestionRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var find = QuestionRepository.GetById(id);
                if (find == null)
                {
                    return NotFound("Not found!");
                }
                return Ok(find);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("Add")]
        public IActionResult Create(QuestionVM questionVM)
        {
            try
            {
                return Ok(QuestionRepository.Create(questionVM));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update/{id}")]
        public IActionResult Update(Question question, int id)
        {
            if (id != question.QuestionId)
            {
                return NotFound("Not found!");
            }
            try
            {
                QuestionRepository.Update(question);
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
            var find = QuestionRepository.GetById(id);
            if (find == null)
            {
                return NotFound("Not found!");
            }
            try
            {
                QuestionRepository.Delete(id);
                return Ok("Delete success!");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
