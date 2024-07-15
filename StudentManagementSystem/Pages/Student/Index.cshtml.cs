using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly studentmsDbContext context;

        public IndexModel(studentmsDbContext context)
        {
            this.context = context;
        }

        public IList<student> Students { get; set; }

        public async Task OnGetAsync()
        {
            Students = await context.students
                .Include(s => s.Department)
                .ToListAsync();

        }
        
    }
    
}
