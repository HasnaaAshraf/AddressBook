using AddressBook.Core.Interfaces.Repositories;
using AddressBook.Core.Models;
using AddressBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure.Repositories
{
	public class JobRepository : IJobRepository
	{
		public readonly AddressBookDbContext _context;

		public JobRepository(AddressBookDbContext context)
		{
			_context = context;
		}

		public async Task<List<Job>> GetAllJobsAsync()
		{
			return await _context.Jobs.ToListAsync();
		}

		public async Task<Job?> GetJobByIdAsync(int id)
		{
			return await _context.Jobs.FindAsync(id);
		}

		public void AddJob(Job job)
		{
		   _context.Add(job);
		}

		public void UpdateJob(Job job)
		{
		   _context.Update(job);
		}

		public void DeleteJob(int id)
		{
			var entity = _context.Jobs.Find(id);
			if (entity != null)
			{
				_context.Jobs.Remove(entity);
			}
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

	}
}
