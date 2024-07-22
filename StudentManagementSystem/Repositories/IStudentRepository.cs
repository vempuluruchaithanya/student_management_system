using Microsoft.EntityFrameworkCore.Update.Internal;
using StudentManagementSystem.Models.Domain;
using StudentManagementSystem.Models.DTO;
using System.Runtime.InteropServices;

namespace StudentManagementSystem.Repositories
{
    public interface IStudentRepository
    {

        Task<List<Student>> GetAllStudentsAsync();

        Task<Student?> GetByIdStudentsAsync(Guid id);

        Task<Student> CreateStudentsAsync(Student student);

        Task<Student?> UpdateStudentsAsync(Guid id, Student student);

        Task<Student?> DeleteStudentsAsync(Guid id);

        
    }
}
