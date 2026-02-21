using AddressBook.Core.Interfaces.Services;
using AddressBook.Core.Models;
using AddressBook.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IDepartmentService _departmentService;

		public DepartmentController(IDepartmentService departmentService)
		{
			_departmentService = departmentService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllDepartments()
		{
			var result = await _departmentService.GetAllDepartmentsAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetDepartmentById(int id)
		{
			var dept = await _departmentService.GetDepartmentByIdAsync(id);
			if (dept == null) return NotFound();
			return Ok(dept);
		}

		[HttpPost]
		public async Task<IActionResult> AddDepartment([FromBody] Department department)
		{
			await _departmentService.AddDepartmentAsync(department);
			await _departmentService.SaveChangesAsync();
			return Ok();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateDepartment(int id, [FromBody] departmentUpdateDto dto)
		{
			var existing = await _departmentService.GetDepartmentByIdAsync(id);
			if (existing == null) return NotFound();

			existing.Name = dto.Name;
			await _departmentService.UpdateDepartmentAsync(existing);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteDepartment(int id)
		{
			var existing = await _departmentService.GetDepartmentByIdAsync(id);
			if (existing == null) return NotFound();

			await _departmentService.DeleteDepartmentAsync(id);
			await _departmentService.SaveChangesAsync();
			return Ok();
		}
	}
}
