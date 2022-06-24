using Microsoft.EntityFrameworkCore;

namespace Student.API.Data
{
    public class StudentBDContext : DbContext
    {
        public StudentBDContext(DbContextOptions<StudentBDContext> options) : base(options)
        {

        }
        public DbSet<Student.API.Data.Model.Student> Student { get; set; }
    }
}
