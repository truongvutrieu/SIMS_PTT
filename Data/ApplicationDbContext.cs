using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlazorApp3.Models;

namespace BlazorApp3.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<BlazorApp3.Models.Semesters> Semesters { get; set; } = default!;
        public DbSet<BlazorApp3.Models.Departments> Departments { get; set; } = default!;
        public DbSet<BlazorApp3.Models.Majors> Majors { get; set; } = default!;
        public DbSet<BlazorApp3.Models.Subjects> Subjects { get; set; } = default!;
        public DbSet<BlazorApp3.Models.Courses> Courses { get; set; } = default!;
        public DbSet<BlazorApp3.Models.StudentCourse> StudentCourses { get; set; } = default!;

        public DbSet<ApplicationUser> ApplicationUser { get; set; } = default!;
    
      
    }
}
