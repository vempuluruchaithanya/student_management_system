namespace StudentManagementSystem.Models.Domain
{
    public class Department
    {
        public Guid DepartmentId { get; set; }

        public string DepartmentName { get; set; }
        
        public string DepartmentHead { get; set; }

   
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

       



    }
}
