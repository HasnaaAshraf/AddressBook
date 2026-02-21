using Microsoft.EntityFrameworkCore;
using AddressBook.Core.Models;
using AddressBook.Infrastructure.Data;
using AddressBook.Application.Services;
using AddressBook.Core.Interfaces.Services;
using AddressBook.Core.Interfaces.Repositories;
using AddressBook.Infrastructure.Repositories;


namespace AddressBook
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAngularDev",
					policy => policy.WithOrigins("http://localhost:4200")
									.AllowAnyHeader()
									.AllowAnyMethod());
			});

			// Add services to the container.
			builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<AddressBookDbContext>(options =>
	        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddScoped<IAddressBookService, AddressBookService>();
			builder.Services.AddScoped<IDepartmentService, DepartmentService>();
			builder.Services.AddScoped<IJobService, JobService>();
			builder.Services.AddScoped<IUserService, UserService>();

			builder.Services.AddScoped<IAddressBookRepository, AddressBookRepository>();
			builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			builder.Services.AddScoped<IJobRepository, JobRepository>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();


			var app = builder.Build();

			app.UseCors("AllowAngularDev");

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
