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
   public class AddItemModel : PageModel
   {
      private readonly ApplicationDbContext _db;

      [BindProperty]
      public Items Items { get; set; }

      public AddItemModel(ApplicationDbContext db)
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

         _db.Items.Add(Items);
         await _db.SaveChangesAsync();

         return Page();
      }
   }
}