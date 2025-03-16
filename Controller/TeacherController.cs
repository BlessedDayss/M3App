using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Microsoft.AspNetCore.OutputCaching;


[OutputCache(Duration=60)]
[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    private readonly M3ManagmentContext _context;

    public TeacherController(M3ManagmentContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Teacher>>> GetTeacher()
    {
        return await _context.Teacher.ToListAsync();
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Teacher>> GetTeacher(int Id)
    {
        var teacher = await _context.Teacher.FindAsync();

        if (teacher == null)
        {
            return NotFound("Unable to find teacher with the given ID");
        }

        return teacher;
    }

    [HttpGet("Name")]
    public async Task<ActionResult<Teacher>> GetTeacherByName(string name)
    {
        var teacher = await _context.Teacher.FirstOrDefaultAsync(t => t.Name == name);
        if (teacher == null)
        {
            return NotFound(new ProblemDetails
            {
                Status = 404,
                Title = "Not Found",
                Detail = $"Teacher with name {name} not found"
            });
        }

        return teacher;
    }

    [HttpGet("Subject")]
    public async Task<ActionResult<Teacher>> GetTeacherBySubject(string subject)
    {
        var teacher = await _context.Teacher.FirstOrDefaultAsync(t => t.Subject == subject);
        if (teacher == null)
        {
            return NotFound("Unable to find teacher with the given subject");
        }

        return teacher;
    }
}
