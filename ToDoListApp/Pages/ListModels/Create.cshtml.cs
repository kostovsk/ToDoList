using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Pages.ListModels
{
   public class CreateModel : PageModel
   {
      private readonly ApplicationDbContext _db;

      [BindProperty]
      public ToDoList ToDoList { get; set; }
      public Items Items { get; set; }

      public CreateModel(ApplicationDbContext db)
      {
         _db = db;
      }

      public IActionResult OnGet()
      {
         return Page();
      }

      public async Task<IActionResult> OnPostAsync()
      {
         if (!ModelState.IsValid)
         {
            return Page();
         }

         ToDoList.DATE_CREATED = DateTime.Now;

         _db.ToDoList.Add(ToDoList);
         await _db.SaveChangesAsync();

         var listId = ToDoList.LIST_ID;

         return RedirectToPage("Edit", new { id = listId });
      }

   }
}
