using AutoMapper;
using DataTable.BLL.Services;
using DataTable.DAL.Entities;
using DataTable.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataTable.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static IUserService _userService;
        private static IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            return users;
        }

        [HttpGet("/api/Controller/Name")]
        public async Task<IEnumerable<User>> GetUsersSortedByNameAsync()
        {
            var users = await _userService.GetUsersSortedByNameAsync();
            return users;
        }

        [HttpGet("/api/Controller/Email")]
        public async Task<IEnumerable<User>> GetUsersSortedByEmailAsync()
        {
            var users = await _userService.GetUsersSortedByEmailAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<User> GetUserAsync(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user;
        }

        [HttpPost]
        public async Task<IActionResult> PostUserAsync(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _mapper.Map<User>(model);
            await _userService.CreateUserAsync(user);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUserAsync(UserModel model, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _mapper.Map<User>(model);
            await _userService.EditUserAsync(user, id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _userService.DeleteUserAsync(id);

            return NoContent();
        }
    }
}
