using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Domain;
using StudentManagementSystem.Models.DTO;

namespace StudentManagementSystem.Repositories
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly StudentmsDbContext dbContext;

        public SQLStudentRepository(StudentmsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Student> CreateStudentsAsync(Student student)
        {
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student?> DeleteStudentsAsync(Guid id)
        {
            var existingStudent = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (existingStudent == null)
            {
                return null;
            }

            dbContext.Students.Remove(existingStudent);
            await dbContext.SaveChangesAsync();
            return existingStudent;

        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await dbContext.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdStudentsAsync(Guid id)
        {
            return await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student?> UpdateStudentsAsync(Guid id, Student student)
        {
            var existingStudent = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.ContactNo = student.ContactNo;
            existingStudent.Email = student.Email;
            existingStudent.CreatedOn = student.CreatedOn;
            existingStudent.ModifiedOn = student.ModifiedOn;

            await dbContext.SaveChangesAsync();
            return existingStudent;

        }
    }
}

      
    

        

        

       
       

