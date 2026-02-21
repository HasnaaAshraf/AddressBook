using AddressBook.Core.Interfaces.Services;
using AddressBook.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressBookController : ControllerBase
	{
		public readonly IAddressBookService _addressBookService;

		public AddressBookController(IAddressBookService addressBookService)
		{
			_addressBookService = addressBookService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAddressBook()
		{
			var result = await _addressBookService.GetAllAddressBooksAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAddressBookById(int id)
		{
			var entry = await _addressBookService.GetAddressBookByIdAsync(id);
			if (entry == null) return NotFound();
			return Ok(entry);
		}

		[HttpPost]
		public async Task<IActionResult> AddAddressBook([FromBody] AddressBookContact addressBook)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState); 

			await _addressBookService.AddAddressBookAsync(addressBook);
			await _addressBookService.SaveChangesAsync();
			return Ok();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAddressBook(int id, [FromBody] AddressBookContact addressBook)
		{
			var existing = await _addressBookService.GetAddressBookByIdAsync(id);
			if (existing == null) return NotFound();

			addressBook.Id = id;
			await _addressBookService.UpdateAddressBookAsync(addressBook);
			await _addressBookService.SaveChangesAsync();
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAddressBook(int id)
		{
			var existing = await _addressBookService.GetAddressBookByIdAsync(id);
			if (existing == null) return NotFound();

			await _addressBookService.DeleteAddressBookAsync(id);
			await _addressBookService.SaveChangesAsync();
			return Ok();
		}

		[HttpGet("search")]
		public async Task<IActionResult> Search(string? name, string? email, DateTime? fromDate, DateTime? toDate)
		{
			var result = await _addressBookService.SearchAddressBooksAsync(name, email, fromDate, toDate);
			return Ok(result);
		}
	}


}

