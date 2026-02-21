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
	public class DepartmentRepository : IDepartmentRepository
	{
		public readonly AddressBookDbContext _context;

		public DepartmentRepository(AddressBookDbContext context)
		{
			_context = context;
		}

		public async Task<List<Department>> GetAllDepartmentsAsync()
		{
			return await _context.Departments.ToListAsync();
		}

		public async Task<Department?> GetDepartmentByIdAsync(int id)
		{
			return await _context.Departments.FindAsync(id);
		}

		public void AddDepartment(Department department)
		{
			_context.Add(department);
		}

		public void UpdateDepartment(Department department)
		{
			_context.Update(department);
		}

		public void DeleteDepartment(int id)
		{
			var entity = _context.Departments.Find(id);
			if (entity != null)
			{
				_context.Remove(entity);
			}
		}


		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

	}
}
