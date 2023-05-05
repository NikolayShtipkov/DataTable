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

        [HttpGet("/api/User/Name")]
        public IEnumerable<User> GetUsersSortedByName()
        {
            var users = _userService.GetUsersSortedByName();
            return users;
        }

        [HttpGet("/api/User/Email")]
        public IEnumerable<User> GetUsersSortedByEmail()
        {
            var users =  _userService.GetUsersSortedByEmail();
            return users;
        }

        [HttpGet("/api/User/Filter/{parameter}")]
        public IEnumerable<User> GetUsersFilteredByParameter(string parameter)
        {
            var users = _userService.GetUsersFilteredByParameter(parameter);
            return users;
        }

        [HttpGet("/api/User/Filter/Role/{number}")]
        public IEnumerable<User> GetUsersFilteredByRole(int number)
        {
            var users = _userService.GetUsersFilteredByRole(number);
            return users;
        }

        [HttpGet("/api/User/Filter/Status/{number}")]
        public IEnumerable<User> GetUsersFilteredByStatus(int number)
        {
            var users = _userService.GetUsersFilteredByStatus(number);
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
