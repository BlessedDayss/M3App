namespace WebApplication1.Models
{
    public sealed class Teacher
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public int Age { get; set; }

        public string Subject { get; set; } = null!;

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}