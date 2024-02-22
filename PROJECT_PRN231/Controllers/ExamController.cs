using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECT_PRN231.Interface;
using PROJECT_PRN231.Models;
using PROJECT_PRN231.Models.ViewModel;

namespace PROJECT_PRN231.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        public IExamRepository _ExamRepository;
        public ExamController(IExamRepository examRepository)
        {
            _ExamRepository = examRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_ExamRepository.GetAll());
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
                var find = _ExamRepository.GetById(id);
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
        public IActionResult Create(ExamVM exam)
        {
            try
            {
                return Ok(_ExamRepository.Create(exam));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("id")]
        public ActionResult Update(int id, Exam exam)
        {
            if (id != exam.ExamId)
            {
                return NotFound();
            }
            try
            {
                _ExamRepository.Update(exam);
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
                _ExamRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
