using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECT_PRN231.Interface;
using PROJECT_PRN231.Models.ViewModel;
using PROJECT_PRN231.Repository;

namespace PROJECT_PRN231.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExamResultController : ControllerBase
    {
        public IUserExamResultRepository UserExamResultRepository;
        public UserExamResultController(IUserExamResultRepository userExamResultRepository)
        {
            UserExamResultRepository = userExamResultRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(UserExamResultRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(UserExamResultVM userExamResult)
        {
            try
            {
                return Ok(UserExamResultRepository.Create(userExamResult));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var find = UserExamResultRepository.GetById(id);
            if (find == null)
            {
                return NotFound("Not found!");
            }
            try
            {
                UserExamResultRepository.Delete(id);
                return Ok("Delete success");
            }
            catch
            {
                return BadRequest();
            }
        }
        
    }
}
