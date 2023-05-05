﻿using DataTable.BLL.Services;
using DataTable.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DataTable.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<User> GetUserAsync(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user;
        }

        [HttpPost]
        public async Task<IActionResult> PostUserAsync(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _userService.CreateUserAsync(user);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUserAsync(User user, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
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
