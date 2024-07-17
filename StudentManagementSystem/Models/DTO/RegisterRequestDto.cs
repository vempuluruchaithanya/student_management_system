using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models.DTO
{
    public class RegisterRequestDto
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username  { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Password { get; set; }

        public String[] Roles { get; set; }



    }
}
