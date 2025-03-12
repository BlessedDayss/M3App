namespace WebApplication1.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using WebApplication1.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly M3ManagmentContext _context;

        public StudentController(M3ManagmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            return await _context.Student.ToListAsync();
        }



        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Student>> GetStudent(int Id)
        {
            var student = await _context.Student.FindAsync(Id);
            if (student == null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = 404,
                    Title = "Not Found",
                    Detail = $"Student with id {Id} not found"
                });
            }
            return student;
        }

        [HttpGet("{Name}")]
        public async Task<ActionResult<Student>> GetStudentByName(string Name)
        {
            var student = await _context.Student.FirstOrDefaultAsync(s => s.Name == Name);

            if (student == null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = 404,
                    Title = "Not Found",
                    Detail = $"Student with name {Name} not found"
                });
            }
            return student;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {

            bool StudentExists = await _context.Student
            .AnyAsync(s => s.Name == student.Name && s.Surname == student.Surname);

            if (StudentExists)
            {
                return BadRequest("Error: A student with the same name and surname already exists");
            }

            if (student.Age <= 0)
            {
                student.Age = new Random().Next(15, 25);
            }

            if (student.Grade <= 0)
            {
                student.Grade = new Random().Next(1, 10);
            }

            if (student.Gpa <= 0)
            {
                student.Gpa = new Random().Next(1, 5);
            }

            if (student.TeacherId == 0)
            {
                var randomTeacher = await _context.Teacher
                    .OrderBy(t => Guid.NewGuid())
                    .FirstOrDefaultAsync();

                if (randomTeacher == null)
                {
                    return BadRequest("Cannot find any teacher, please add teacher first");
                }

                student.TeacherId = randomTeacher.Id;
            }
            _context.Student.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { Id = student.Id }, student);
        }

        [HttpPut("{Id:int}")]
        public async Task<IActionResult> PutStudent(int Id, Student student)
        {
            if (Id != student.Id)
            {
                return BadRequest();
            }
            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }


        // [HttpDelete("Id")]

        private bool StudentExists(int Id)
        {
            return _context.Student.Any(s => s.Id == Id);
        }
    }

}