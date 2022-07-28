using Interview_Task2.Entity;
using Interview_Task2.Services;
using Interview_Task2.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Interview_Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>?> Get()
        {
            return await _userService.Get();
        }

        // GET api/<UserController>/123
        [HttpGet("{id}")]
        public async Task<User?> Get(Guid id)
        {
            return await _userService.Get(id);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var register = await _userService.RegisterAsync(user);
            if (!register)
                return BadRequest("Tài khoản đã tồn tại");
            return Ok("Successful");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var login = await _userService.LoginAsync(loginViewModel);
            if (!login)
                return BadRequest("Sai tài khoản hoặc mật khẩu. Đăng nhập lại...");
            return Ok("Successful");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _userService.Delete(id);
        }
    }
}
