using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyRestApi.Models;
using MyRestApi.Models.DTOs;
using MyRestApi.Services;

namespace MyRestApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<User>>> GetUsers()
		{
			var users = await _userService.GetAllUsersAsync();
			return Ok(users);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetUser(int id)
		{
			try
			{
				var user = await _userService.GetUserByIdAsync(id);
				return Ok(user);
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpPost]
		public async Task<ActionResult<User>> CreateUser(UserCreateDto userDto)
		{
			try
			{
				var user = await _userService.CreateUserAsync(userDto);
				return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
			}
			catch (InvalidOperationException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUser(int id, UserUpdateDto userDto)
		{
			try
			{
				var user = await _userService.UpdateUserAsync(id, userDto);
				return Ok(user);
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (InvalidOperationException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			try
			{
				await _userService.DeleteUserAsync(id);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpPost("authenticate")]
		public async Task<ActionResult<User>> Authenticate([FromBody] LoginDto credentials)
		{
			var user = await _userService.AuthenticateAsync(credentials.Email, credentials.Password);
			if (user == null)
				return Unauthorized("Invalid email or password");

			return Ok(user);
		}
	}
}