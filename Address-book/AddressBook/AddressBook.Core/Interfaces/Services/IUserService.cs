using AddressBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Core.Interfaces.Services
{
	public interface IUserService
	{
		Task<User> LoginAsync(string userName, string password);
		Task<User?> GetUserByUserNameAsync(string userName);
		void AddUser(User user);
		Task SaveChangesAsync();
	}
}
