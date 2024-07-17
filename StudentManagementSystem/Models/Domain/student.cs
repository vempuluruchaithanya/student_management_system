using System.Globalization;

namespace StudentManagementSystem.Models.Domain
{
    public class Student
    {

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContactNo { get; set; }

        public string Email { get; set; }


        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }


        


    }
}
