namespace WebApplication1.Models
{

    using Microsoft.EntityFrameworkCore;

    public class M3ManagmentContext(DbContextOptions<M3ManagmentContext> options) : DbContext(options)
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; } 
    }
}
