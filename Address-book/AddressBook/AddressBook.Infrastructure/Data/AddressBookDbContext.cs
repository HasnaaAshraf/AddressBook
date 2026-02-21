using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AddressBook.Core.Models;


namespace AddressBook.Infrastructure.Data
{
	public class AddressBookDbContext : DbContext
	{
		public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options)
		: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<AddressBookContact>()
				.HasOne(a => a.User)
				.WithMany(b => b.AddressBooks)
				.HasForeignKey(a => a.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<AddressBookContact>()
				.HasOne(a => a.Job)
				.WithMany(b => b.AddressBooks)
				.HasForeignKey(a => a.JobId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<AddressBookContact>()
			.HasOne(a => a.Department)
			.WithMany(b => b.AddressBooks)
			.HasForeignKey(a => a.DepartmentId)
			.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<AddressBookContact>()
				.Property(a => a.Email)
				.IsRequired()
				.HasMaxLength(100);

			modelBuilder.Entity<AddressBookContact>()
				.Property(a => a.MobileNumber)
				.IsRequired()
				.HasMaxLength(20);

		}

		public DbSet<User> Users { get; set; }
		public DbSet<AddressBookContact> AddressBooks { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Department> Departments { get; set; }

	}
}
