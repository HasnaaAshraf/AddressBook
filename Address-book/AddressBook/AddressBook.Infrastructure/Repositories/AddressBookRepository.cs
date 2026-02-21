using AddressBook.Core.Interfaces.Repositories;
using AddressBook.Core.Models;
using AddressBook.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace AddressBook.Infrastructure.Repositories
{
	public class AddressBookRepository : IAddressBookRepository
	{
		public readonly AddressBookDbContext _context;

		public AddressBookRepository(AddressBookDbContext context)
		{
			_context = context;
		}

		public async Task<List<AddressBookContact>> GetAllAddressBookAsync()
		{
			return await _context.AddressBooks
						 .Include(a => a.Department)
						 .Include(a => a.Job)
						 .Include(a => a.User)
						 .ToListAsync();
		}

		public AddressBookContact? GetAddressBookByIdAsync(int Id)
		{
			return _context.AddressBooks.AsNoTracking().FirstOrDefault(a =>a.Id == Id);
		}


		public void AddAddressBook(AddressBookContact addressBook)
		{
		   _context.Add(addressBook);
		}

		public void UpdateAddressBook(AddressBookContact addressBook)
		{
			 _context.Update(addressBook);
		}

		public void DeleteAddressBook(int Id)
		{
			var entity = _context.AddressBooks.Find(Id); 
			if (entity != null)
			{
				_context.AddressBooks.Remove(entity);   
			}
		}

		public async Task<List<AddressBookContact>> SearchByAddressBookAsync(string? name, 
			                                                                 string? email, DateTime? fromDate, DateTime? toDate)
		{
			var query = _context.AddressBooks.AsQueryable();

			if (!string.IsNullOrWhiteSpace(name))
				query = query.Where(x => x.FullName.Contains(name));

			if (!string.IsNullOrWhiteSpace(email))
				query = query.Where(x => x.Email.Contains(email));

			if (fromDate.HasValue)
				query = query.Where(x => x.DateOfBirth >= fromDate.Value);

			if (toDate.HasValue)
				query = query.Where(x => x.DateOfBirth <= toDate.Value);

			return await query.ToListAsync();
		}

		public async Task SaveChangesAsync()
		{
		  await	_context.SaveChangesAsync();
		}

	}
}
