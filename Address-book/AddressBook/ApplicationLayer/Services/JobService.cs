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
	public class JobService : IJobService
	{

		public readonly IJobRepository _jobRepository;

		public JobService(IJobRepository jobRepository)
		{
			_jobRepository = jobRepository;
		}

		public async Task<List<Job>> GetAllJobsAsync()
		{
			return await _jobRepository.GetAllJobsAsync();
		}

		public async Task<Job?> GetJobByIdAsync(int id)
		{
			return await _jobRepository.GetJobByIdAsync(id);
		}

		public async Task AddJobAsync(Job job)
		{
			if (job == null) throw new ArgumentNullException(nameof(job));
			_jobRepository.AddJob(job);
		    await _jobRepository.SaveChangesAsync();
		}

		public async Task UpdateJobAsync(Job job)
		{
			_jobRepository.UpdateJob(job);
			await _jobRepository.SaveChangesAsync();
		}


		public async Task DeleteJobAsync(int id)
		{
			if(id == 0) throw new ArgumentNullException("id");
		     _jobRepository.DeleteJob(id);
			await _jobRepository.SaveChangesAsync();
		}

		public async Task SaveChangesAsync()
		{
			await _jobRepository.SaveChangesAsync();
		}

	}
}
