using AddressBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Core.Interfaces.Services
{
	public interface IJobService
	{
		Task<List<Job>> GetAllJobsAsync();
		Task<Job?> GetJobByIdAsync(int id);
		Task AddJobAsync(Job job);
		Task UpdateJobAsync(Job job);
		Task DeleteJobAsync(int id);
		Task SaveChangesAsync();
	}
}
