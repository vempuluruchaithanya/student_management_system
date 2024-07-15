namespace StudentManagementSystem.Models
{
    public class department
    {

        public Guid Id { get; set; }

        public Guid studentId { get; set; }

        public string departmentName { get; set; }

        public string departmentHeadName {  get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
