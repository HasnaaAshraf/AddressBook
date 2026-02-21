using AddressBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Core.Interfaces.Repositories
{
	public interface IAddressBookRepository
	{
		Task<List<AddressBookContact>> GetAllAddressBookAsync();

		AddressBookContact GetAddressBookByIdAsync(int Id);

		void AddAddressBook(AddressBookContact addressBook);

		void UpdateAddressBook(AddressBookContact addressBook);

		void DeleteAddressBook(int Id);

		Task<List<AddressBookContact>> SearchByAddressBookAsync(string? name,
			                                                    string? email,
																DateTime? fromDate,DateTime? toDate);


		Task SaveChangesAsync();

	}
}
