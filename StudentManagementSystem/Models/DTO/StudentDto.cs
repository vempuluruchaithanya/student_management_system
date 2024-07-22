using StudentManagementSystem.Models.Domain;

namespace StudentManagementSystem.Models.DTO
{
    public class StudentDto
    {


        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContactNo { get; set; }

        public string Email { get; set; }


        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public Guid DepartmentId { get; set; }



    }
}
