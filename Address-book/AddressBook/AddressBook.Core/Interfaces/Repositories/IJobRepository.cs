using AddressBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Core.Interfaces.Repositories
{
	public interface IJobRepository
	{
		Task<List<Job>> GetAllJobsAsync();

		Task<Job> GetJobByIdAsync(int id);

		void AddJob(Job job);

		void UpdateJob(Job job);

		void DeleteJob(int id);

		Task SaveChangesAsync();

	}
}
