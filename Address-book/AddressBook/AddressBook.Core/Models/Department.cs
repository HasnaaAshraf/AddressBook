using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AddressBook.Core.Models
{
	public class Department
	{
		public int Id { get; set; }
		public string Name { get; set; }
		[JsonIgnore]
		public ICollection<AddressBookContact>? AddressBooks { get; set; }
	}
}
