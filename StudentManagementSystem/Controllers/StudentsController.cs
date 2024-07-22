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
    //[Authorize]
    public class StudentsController : ControllerBase
    {
        
        private readonly IStudentRepository studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            
            this.studentRepository = studentRepository;
        }


        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var studentsDomain = await studentRepository.GetAllStudentsAsync();
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
            catch (Exception ex)
            {
                return NotFound();

            }

        }

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            try
            {
                var studentDomain = await studentRepository.GetByIdStudentsAsync(id);

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
            catch (Exception ex)
            {

                return NotFound();

            }

        }


        [HttpPost]
       // [Authorize(Roles = "Writer")]

        public async Task<IActionResult> Create([FromBody] AddStudentRequestDto addStudentRequestDto)
        {
            try 
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

                studentDomainModel = await studentRepository.CreateStudentsAsync(studentDomainModel);

                var studentDto = new StudentDto
                {
                    Id = studentDomainModel.Id,
                    FirstName = studentDomainModel.FirstName,
                    LastName = studentDomainModel.LastName,
                    ContactNo = studentDomainModel.ContactNo,
                    Email = studentDomainModel.Email,
                    CreatedOn = studentDomainModel.CreatedOn,
                    ModifiedOn = studentDomainModel.ModifiedOn
                };

                return CreatedAtAction(nameof(GetById), new { id = studentDto.Id }, studentDto);

            }

            catch (Exception ex) 
            {
                return NotFound();

            }
        }

        [HttpPut]
        [Route("{id:Guid}")]
       // [Authorize(Roles = "Writer")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateStudentRequestDto updateStudentRequestDto)
        {
            try
            {
                var studentDomainModel = new Student
                {
                    FirstName = updateStudentRequestDto.FirstName,
                    LastName = updateStudentRequestDto.LastName,
                    ContactNo = updateStudentRequestDto.ContactNo,
                    Email = updateStudentRequestDto.Email,
                    CreatedOn = updateStudentRequestDto.CreatedOn,
                    ModifiedOn = updateStudentRequestDto.ModifiedOn

                };

                studentDomainModel = await studentRepository.UpdateStudentsAsync(id, studentDomainModel);
                if (studentDomainModel == null)
                {
                    return NotFound();
                }

                studentDomainModel.FirstName = updateStudentRequestDto.FirstName;
                studentDomainModel.LastName = updateStudentRequestDto.LastName;
                studentDomainModel.ContactNo = updateStudentRequestDto.ContactNo;
                studentDomainModel.Email = updateStudentRequestDto.Email;
                studentDomainModel.CreatedOn = updateStudentRequestDto.CreatedOn;
                studentDomainModel.ModifiedOn = updateStudentRequestDto.ModifiedOn;

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

            catch (Exception ex) 
            {
                return NotFound();

            }
            
        }


        [HttpDelete]
        [Route("{id:Guid}")]
      // [Authorize(Roles = "Writer,Reader")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var studentDomainModel = await studentRepository.DeleteStudentsAsync(id);
                if (studentDomainModel == null)
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
            catch (Exception ex)

            {
                return NotFound();
            }
           

        }

    }
}



