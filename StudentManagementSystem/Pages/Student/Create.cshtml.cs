using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly studentmsDbContext context;

        public CreateModel(studentmsDbContext context)
        {
            this.context = context;
        }

        public IActionResult OnGet()
        {
            department = new SelectList(context.departments, "Id", "DepName");
            return Page();
        }
        
        }
    }

