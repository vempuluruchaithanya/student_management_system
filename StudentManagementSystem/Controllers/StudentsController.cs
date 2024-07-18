using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.Domain;
using StudentManagementSystem.Models.DTO;
using StudentManagementSystem.Repositories;


namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly StudentmsDbContext dbContext;
        private readonly IStudentRepository studentRepository;

        public StudentsController(StudentmsDbContext dbContext, IStudentRepository studentRepository)
        {
            this.dbContext = dbContext;
            this.studentRepository = studentRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var studentsDomain = await studentRepository.GetAllAsync();




            var studentsDto = new List<StudentDto>();
            foreach (var studentDomain in studentsDomain)
            {
                studentsDto.Add(new StudentDto()
                {
                    Id = studentDomain.Id,
                    FirstName = studentDomain.FirstName,
                    LastName = studentDomain.LastName,
                    ContactNo = studentDomain.ContactNo,
                    Email = studentDomain.Email,
                    CreatedOn = studentDomain.CreatedOn,
                    ModifiedOn = studentDomain.ModifiedOn,
                });
            }

            return Ok(studentsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var studentDomain = await studentRepository.GetByIdAsync(id);

            if (studentDomain == null)
            {
                return NotFound();
            }
            var studentDto = new StudentDto
            {
                Id = studentDomain.Id,
                FirstName = studentDomain.FirstName,
                LastName = studentDomain.LastName,
                ContactNo = studentDomain.ContactNo,
                Email = studentDomain.Email,
                CreatedOn = studentDomain.CreatedOn,
                ModifiedOn = studentDomain.ModifiedOn,


            };

            return Ok(studentDto);



        }


        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddStudentRequestDto addStudentRequestDto)
        {
            

            var studentDomainModel = new Student
            {
                FirstName = addStudentRequestDto.FirstName,
                LastName = addStudentRequestDto.LastName,
                ContactNo = addStudentRequestDto.ContactNo,
                Email = addStudentRequestDto.Email,
                CreatedOn = addStudentRequestDto.CreatedOn,
                ModifiedOn = addStudentRequestDto.ModifiedOn
                
                           
            };

            studentDomainModel = await studentRepository.CreateAsync(studentDomainModel);

            var studentDto = new StudentDto
            {
                Id = studentDomainModel.Id,
                FirstName = studentDomainModel.FirstName,
                LastName = studentDomainModel.LastName,
                ContactNo = studentDomainModel.ContactNo,
                Email= studentDomainModel.Email,
                CreatedOn = studentDomainModel.CreatedOn,
                ModifiedOn = studentDomainModel.ModifiedOn
              
                            
            };

            return CreatedAtAction(nameof(GetById), new { id = studentDto.Id }, studentDto);








    }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateStudentRequestDto updateStudentRequestDto)
        {
            var studentDomainModel = new Student
            { 
                FirstName = updateStudentRequestDto.FirstName,
                LastName = updateStudentRequestDto.LastName,
                ContactNo= updateStudentRequestDto.ContactNo,
                Email= updateStudentRequestDto.Email,
                CreatedOn = updateStudentRequestDto.CreatedOn,
                ModifiedOn= updateStudentRequestDto.ModifiedOn
            
            
            
            };

            studentDomainModel = await studentRepository.UpdateAsync(id, studentDomainModel);
            if(studentDomainModel == null)
            {
                return NotFound();
            }

            studentDomainModel.FirstName = updateStudentRequestDto.FirstName;
            studentDomainModel.LastName = updateStudentRequestDto.LastName;
            studentDomainModel.ContactNo = updateStudentRequestDto.ContactNo;
            studentDomainModel.Email = updateStudentRequestDto.Email;
            studentDomainModel.CreatedOn = updateStudentRequestDto.CreatedOn;
            studentDomainModel.ModifiedOn = updateStudentRequestDto.ModifiedOn;
            

            dbContext.SaveChanges();

            var studentDto = new StudentDto
            {
                Id = studentDomainModel.Id,
                FirstName = studentDomainModel.FirstName,
                LastName = studentDomainModel.LastName,
                ContactNo = studentDomainModel.ContactNo,
                Email = studentDomainModel.Email,
                CreatedOn = studentDomainModel.CreatedOn,
                ModifiedOn = studentDomainModel.ModifiedOn,
                

            };


            return Ok(studentDto);
        }


        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var studentDomainModel = await studentRepository.DeletAsync(id);

            if(studentDomainModel == null)
            {
                return NotFound();
            }

           

            var studentDto = new StudentDto
            {
                Id = studentDomainModel.Id,
                FirstName = studentDomainModel.FirstName,
                LastName = studentDomainModel.LastName,
                ContactNo = studentDomainModel.ContactNo,
                Email = studentDomainModel.Email,
                CreatedOn = studentDomainModel.CreatedOn,
                ModifiedOn = studentDomainModel.ModifiedOn,
                

            };

            return Ok(studentDto);





        }



    }
}


