using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.Models
{
    public sealed class Student
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public int Age { get; set; }

        public int Grade { get; set; }

        public decimal Gpa { get; set; }

        public int TeacherId { get; set; }

        [ValidateNever]
        public Teacher Teacher { get; set; } = null!;
    }
}