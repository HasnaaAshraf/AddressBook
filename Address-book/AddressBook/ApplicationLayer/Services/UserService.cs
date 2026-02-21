using AddressBook.Core.Interfaces.Repositories;
using AddressBook.Core.Interfaces.Services;
using AddressBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Application.Services
{
	public class UserService : IUserService
	{
		public readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public void AddUser(User user)
		{
		   _userRepository.AddUser(user);
		}

		public async Task<User?> GetUserByUserNameAsync(string userName)
		{
			return await _userRepository.GetUserByUserNameAsync(userName);
		}

		public async Task<User> LoginAsync(string userName, string password)
		{
			var user = await _userRepository.GetUserByUserNameAsync(userName);

			if (user == null)
				return null;

			var hashedPassword = HashPassword(password);
			if (user.PasswordHash != hashedPassword)
				return null;

			return user;
		}

		private string HashPassword(string password)
		{
			using var sha256 = SHA256.Create();
			var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
			return Convert.ToBase64String(bytes);
		}
		public async Task SaveChangesAsync()
		{
		   await _userRepository.SaveChangesAsync();
		}
	}
}
