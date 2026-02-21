using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AddressBook.Core.Models
{
	public class AddressBookContact
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string MobileNumber { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string PhotoPath { get; set; }
		public int Age => DateTime.Now.Year - DateOfBirth.Year;
		public int DepartmentId { get; set; }
	
		public Department? Department { get; set; }

		public int JobId {  get; set; }
	
		public Job ?Job { get; set; }

		public int UserId { get; set; }
	
		public User? User { get; set; }

	}
}
