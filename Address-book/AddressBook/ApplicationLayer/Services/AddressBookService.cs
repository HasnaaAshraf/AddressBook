using AddressBook.Core.Interfaces.Repositories;
using AddressBook.Core.Interfaces.Services;
using AddressBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Application.Services
{
	public class AddressBookService : IAddressBookService
	{
		public readonly IAddressBookRepository _addressBookRepository;

		public AddressBookService(IAddressBookRepository addressBookRepository)
		{
			_addressBookRepository = addressBookRepository;
		}

		public async Task<List<AddressBookContact>> GetAllAddressBooksAsync()
		{
			return await _addressBookRepository.GetAllAddressBookAsync();
		}

		public async Task<AddressBookContact?> GetAddressBookByIdAsync(int id)
		{
			return _addressBookRepository.GetAddressBookByIdAsync(id);
		}


		public async Task AddAddressBookAsync(AddressBookContact addressBook)
		{
			if (addressBook == null) throw new ArgumentNullException(nameof(addressBook));

			_addressBookRepository.AddAddressBook(addressBook);
		    await _addressBookRepository.SaveChangesAsync();
		}

		public async Task UpdateAddressBookAsync(AddressBookContact addressBook)
		{
			_addressBookRepository.UpdateAddressBook(addressBook);
			await _addressBookRepository.SaveChangesAsync();
		}

		public async Task DeleteAddressBookAsync(int id)
		{
			if(id < 0) throw new ArgumentOutOfRangeException(nameof(id));
		    _addressBookRepository.DeleteAddressBook(id);
			await _addressBookRepository.SaveChangesAsync();
		}


		public async Task<List<AddressBookContact>> SearchAddressBooksAsync(string? name,
			                                                          string? email, DateTime? fromDate, DateTime? toDate)
		{
			return await _addressBookRepository.SearchByAddressBookAsync(name, email, fromDate, toDate);
		}

		public async Task SaveChangesAsync()
		{
			await _addressBookRepository.SaveChangesAsync();
		}

	}
}
