using AddressBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Core.Interfaces.Repositories
{
	public interface IDepartmentRepository
	{
		Task<List<Department>> GetAllDepartmentsAsync();

		Task<Department> GetDepartmentByIdAsync(int id);

		void AddDepartment(Department department);

		void UpdateDepartment(Department department);

		void DeleteDepartment(int id);

		Task SaveChangesAsync();

	}
}
