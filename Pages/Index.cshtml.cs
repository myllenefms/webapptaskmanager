using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppTaskManager.Models;

namespace WebAppTaskManager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TaskContext _context;

        public IndexModel(TaskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Title { get; set; }
        public List<TaskItem> Tasks { get; set; }

        public void OnGet()
        {
            Tasks = _context.Tasks.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(Title))
            {
                var task = new TaskItem { Title = Title, IsCompleted = false };
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
