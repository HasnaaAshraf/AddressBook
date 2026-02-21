
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
	public class DepartmentService : IDepartmentService
	{
		public readonly IDepartmentRepository _departmentRepository;

		public DepartmentService(IDepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}

		public async Task<List<Department>> GetAllDepartmentsAsync()
		{
			return await _departmentRepository.GetAllDepartmentsAsync();
		}

		public async Task<Department?> GetDepartmentByIdAsync(int id)
		{
			return await _departmentRepository.GetDepartmentByIdAsync(id);
		}

		public async Task AddDepartmentAsync(Department department)
		{
			if (department == null) throw new ArgumentNullException(nameof(department));
            _departmentRepository.AddDepartment(department);
			await _departmentRepository.SaveChangesAsync();
		}

		public async Task UpdateDepartmentAsync(Department department)
		{
		    _departmentRepository.UpdateDepartment(department);
			await _departmentRepository.SaveChangesAsync();
		}

		public async Task DeleteDepartmentAsync(int id)
		{
			if(id == 0) throw new ArgumentNullException("id");
		    _departmentRepository.DeleteDepartment(id);
			await _departmentRepository.SaveChangesAsync();
		}

		public async Task SaveChangesAsync()
		{
			await _departmentRepository.SaveChangesAsync();
		}
		
	}
}
