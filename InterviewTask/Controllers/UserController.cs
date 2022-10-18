using InterviewTask.Dto;
using InterviewTask.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InterviewTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context = null)
        {
            _context = context;
        }


        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserInput input)
        {
            User user = new User()
            {
                Name = input.Name,
                UserName = input.UserName,
                Password = input.Password,
                Phone = input.Phone,
                RoleId = input.RoleId,
            };
            var response = await _context.AddAsync(input);
            return Ok(response);
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserInput input)
        {
            var response = await _context.Users.FirstOrDefaultAsync(x => x.UserName == input.UserName && x.Password == input.Password);
            if (response == null)
            {
                return BadRequest("Invalid Credentials");
            }

            var Claim = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,input.UserName)
            };

            return Ok();
        }

        [Route("Users")]
        [HttpGet]
        public async Task<IActionResult> GetRegisterUsers()
        {
            var users = await _context.Users.Include(x => x.RoleFK).ToListAsync();
            return Ok(users);
        }

    }
}
