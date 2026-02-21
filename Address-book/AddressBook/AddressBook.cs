using System;
using AddressBook.Domain_Layer.Entities;

namespace AddressBook.Domain_Layer.Entities
{ 
	public class AddressBook
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public int MobileNumber { get; set; }
		public int DateOfBirth { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string PhotoPath { get; set; }

		// Foreign key to Department
		public int DepartmentId { get; set; }
		public Department Department { get; set; }

	}
}