using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Data
{
    public class StudentmsAuthDbContext : IdentityDbContext
    {
        public StudentmsAuthDbContext(DbContextOptions<StudentmsAuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "64b706cb-215c-4357-803b-526da522268f";
            var writerRoleId = "2909112b-5020-4f94-8f55-d67b21967939";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()

                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
             
              
        }
    }
}
