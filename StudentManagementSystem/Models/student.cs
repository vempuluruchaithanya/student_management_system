namespace StudentManagementSystem.Models
{
    public class student
    {
        internal readonly object Department;

        public Guid Id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }


        public string contactNo { get; set; }

        public string email { get; set; }

        public Guid DepartmentId { get; set; }
        public string department { get; set; }



        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }


    }
}
