using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            Departments = new SelectList(context.departments, "Id", "DepName");
            return Page();
        }
        public student Student { get; set; }
        public SelectList Departments { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Student.Id = Guid.NewGuid();
            context.students.Add(Student);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}
    

