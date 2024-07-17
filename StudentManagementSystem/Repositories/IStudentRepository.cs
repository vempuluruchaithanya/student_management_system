using Microsoft.EntityFrameworkCore.Update.Internal;
using StudentManagementSystem.Models.Domain;
using System.Runtime.InteropServices;

namespace StudentManagementSystem.Repositories
{
    public interface IStudentRepository
    {

        Task<List<Student>> GetAllAsync();

        Task<Student?> GetByIdAsync(Guid id);

        Task<Student> CreateAsync(Student student);

        Task<Student?> UpdateAsync(Guid id, Student student);

        Task<Student?> DeletAsync(Guid id);
    }
}
