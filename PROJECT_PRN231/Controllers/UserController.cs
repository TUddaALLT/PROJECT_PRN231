using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PROJECT_PRN231.Interface;
using PROJECT_PRN231.Models;

namespace PROJECT_PRN231.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var list = _userRepository.GetAll();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }
    }
}
