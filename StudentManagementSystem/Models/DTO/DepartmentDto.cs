using StudentManagementSystem.Models.Domain;

namespace StudentManagementSystem.Models.DTO
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }

        public string DepartmentName { get; set; }

        public string DepartmentHead { get; set; }


        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        
    }
}
