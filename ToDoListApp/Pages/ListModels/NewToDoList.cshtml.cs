using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Pages.ListModels
{
    public class NewToDoList : PageModel
    {
        private readonly ApplicationDbContext _db;

        public NewToDoList(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<ToDoList> ArrayOfToDoLists { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ArrayOfToDoLists = await _db.ToDoList.ToListAsync();
            return Page();
        }
    }
}