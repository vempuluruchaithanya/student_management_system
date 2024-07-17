using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models.Domain;

namespace StudentManagementSystem.Data
{
    public class StudentmsDbContext: DbContext
    {

        public StudentmsDbContext(DbContextOptions <StudentmsDbContext> dbContextOptions) : base(dbContextOptions) { }
        
        public DbSet<Student> Students {  get; set; }

        public DbSet<Department> Departments { get; set; } 



     

    }
}
