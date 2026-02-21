using AddressBook.Core.Interfaces.Services;
using AddressBook.Core.Models;
using AddressBook.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
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

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
		{
			var user = await _userService.LoginAsync(loginDto.UserName, loginDto.Password);
			if (user == null)
				return Unauthorized(new { message = "Username or password is incorrect" });

			return Ok(new { user.Id, user.UserName, user.Email });
		}

		[HttpGet("{userName}")]
		public async Task<IActionResult> GetUserByUserName(string userName)
		{
			var user = await _userService.GetUserByUserNameAsync(userName);
			if (user == null) return NotFound();
			return Ok(user);
		}

		[HttpPost]
		public async Task<IActionResult> AddUser([FromBody] User user)
		{
			_userService.AddUser(user);
			await _userService.SaveChangesAsync();
			return Ok();
		}
	}
}
