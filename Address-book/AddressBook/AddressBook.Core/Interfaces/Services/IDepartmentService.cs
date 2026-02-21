using AddressBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Core.Interfaces.Services
{
	public interface IDepartmentService
	{
		Task<List<Department>> GetAllDepartmentsAsync();
		Task<Department?> GetDepartmentByIdAsync(int id);
		Task AddDepartmentAsync(Department department);
		Task UpdateDepartmentAsync(Department department);
		Task DeleteDepartmentAsync(int id);
		Task SaveChangesAsync();
	}
}
