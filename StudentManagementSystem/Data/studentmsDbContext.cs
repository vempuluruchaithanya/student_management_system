using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class studentmsDbContext: DbContext
    {

        public studentmsDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        
        public DbSet<student> students {  get; set; }

        public DbSet<department> departments { get; set; } 



        



    }
}
