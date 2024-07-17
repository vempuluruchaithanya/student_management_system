﻿using StudentManagementSystem.Models.Domain;

namespace StudentManagementSystem.Models.DTO
{
    public class UpdateStudentRequestDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContactNo { get; set; }

        public string Email { get; set; }


        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }


        

    }
}
