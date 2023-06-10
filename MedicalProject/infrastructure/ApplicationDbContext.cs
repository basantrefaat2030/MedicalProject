using MedicalProject.Infrastructure.Entities;
using MedicalProject.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalProject.Infrastructure.Entities
{
	public class ApplicationDbContext:DbContext
	{

	    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{

		}
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<Attachments> Attachments { get; set; }

        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<BlogType> BlogTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentServices> DepartmentServices { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSchedules> DoctorSchedules { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } 


    }
}
