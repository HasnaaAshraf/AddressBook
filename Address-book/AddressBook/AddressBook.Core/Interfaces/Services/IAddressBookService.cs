using AddressBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Core.Interfaces.Services
{
	public interface IAddressBookService
	{
		Task<List<AddressBookContact>> GetAllAddressBooksAsync();
		Task<AddressBookContact?> GetAddressBookByIdAsync(int id);
		Task AddAddressBookAsync(AddressBookContact addressBook);
		Task UpdateAddressBookAsync(AddressBookContact addressBook);
		Task DeleteAddressBookAsync(int id);
		Task SaveChangesAsync();
		Task<List<AddressBookContact>> SearchAddressBooksAsync(string? name, 
			                                                   string? email, DateTime? fromDate, DateTime? toDate);
	}
}
