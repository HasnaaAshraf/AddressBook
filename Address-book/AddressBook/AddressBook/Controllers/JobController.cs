using AddressBook.Core.Interfaces.Services;
using AddressBook.Core.Models;
using AddressBook.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobController : ControllerBase
	{
		public readonly IJobService _jobService;

		public JobController(IJobService jobService)
		{
			_jobService = jobService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllJobs()
		{
			var result = await _jobService.GetAllJobsAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetJobById(int id)
		{
			var job = await _jobService.GetJobByIdAsync(id); 
			if (job == null) return NotFound();
			return Ok(job);
		}

		[HttpPost]
		public async Task<IActionResult> AddJob([FromBody] Job job)
		{
			if (job == null || string.IsNullOrEmpty(job.Title))
				return BadRequest("Job title is required");

			await _jobService.AddJobAsync(job); 
			await _jobService.SaveChangesAsync(); 
			return Ok(job);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateJob(int id, [FromBody] JobUpdateDTO jobDto)
		{
			if (id != jobDto.Id)
				return BadRequest("Id mismatch");

			var existingJob = await _jobService.GetJobByIdAsync(id);
			if (existingJob == null)
				return NotFound();

			existingJob.Title = jobDto.Title;

			await _jobService.UpdateJobAsync(existingJob);
			await _jobService.SaveChangesAsync();

			return Ok(existingJob);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteJob(int id)
		{
			var existing = await _jobService.GetJobByIdAsync(id);
			if (existing == null) return NotFound();

			await _jobService.DeleteJobAsync(id);
			await _jobService.SaveChangesAsync();
			return Ok();
		}
	}


}

