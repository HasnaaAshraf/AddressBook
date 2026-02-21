using AddressBook.Core.Interfaces.Repositories;
using AddressBook.Core.Models;
using AddressBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{

		public readonly AddressBookDbContext _context;

		public UserRepository(AddressBookDbContext context)
		{
			_context = context;
		}

		public async Task<User?> GetUserByUserNameAsync(string userName)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
		}

		public void AddUser(User user)
		{
			_context.Users.Add(user);
		}

		public async Task SaveChangesAsync()
		{
		   await _context.SaveChangesAsync();
		}
	}
}
