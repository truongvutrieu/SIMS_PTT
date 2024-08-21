using BlazorApp3.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp3.API
{

    [Route("api/[controller]")]
    [ApiController]

    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchStudents(string? term, int courseId)
        {
            var students = await _context.Users
            .Where(u => u.Role == "Student" &&
                            !_context.StudentCourses.Any(sc => sc.CourseId == courseId && sc.StudentId == u.Id) &&
                            (u.Name.Contains(term) || u.Email.Contains(term) || u.Code.Contains(term)))
                .Select(u => new { id = u.Id, text = u.Name + " (" + u.Email + ")" })
                .ToListAsync();

            return Ok(students);
        }
    }
}
