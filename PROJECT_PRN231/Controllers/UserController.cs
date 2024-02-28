using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PROJECT_PRN231.Interface;
using PROJECT_PRN231.Models;
using System.Security.Cryptography;

namespace PROJECT_PRN231.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly AppSettings _applicationSettings;
        private readonly IUserRepository _userRepository;
        public UserController(IOptions<AppSettings> applicationSettings, IUserRepository userRepository)
        {
            _applicationSettings = applicationSettings.Value;
            _userRepository = userRepository;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("GetAll")]
        public IActionResult GetAllUsers()
        {
            var list = _userRepository.GetAll();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword([FromBody] ChangePassword model) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userExist = _userRepository.GetByUserName(model.Username);
            if (userExist == null)
            {
                return NotFound();
            }
            if (!CheckPassword(model.OldPassword, userExist))
            {
                return BadRequest("Invalid old password");
            }
            if (model.NewPassword != model.ConfirmNewPassword)
            {
                return BadRequest("New password and Confirm password not correct");
            }
            using (HMACSHA512? hmac = new HMACSHA512())
            {
                userExist.PasswordSalt = hmac.Key;
                userExist.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(model.NewPassword));
            }
            if (_userRepository.UpdateUser(userExist))
            {
                return Ok(userExist);
            }
            else
            {
                ModelState.AddModelError("", "Error when change password");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public bool CheckPassword(string password, User user)
        {
            bool result;
            using (HMACSHA512? hmac = new HMACSHA512(user.PasswordSalt))
            {
                var compute = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                result = compute.SequenceEqual(user.PasswordHash);
            }
            return result;
        }
    }
}
