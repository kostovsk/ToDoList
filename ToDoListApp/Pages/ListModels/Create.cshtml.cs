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

      public CreateModel(ApplicationDbContext db)
      {
         _db = db;
      }

      
      public ToDoList ToDoList { get; set; }
      [BindProperty]
      public Items Item { get; set; }
      public IList<Items> ArrayItems { get; set; }

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
         foreach (var item in ArrayItems)
         {
            _db.Items.Add(item);
         }
         await _db.SaveChangesAsync();

         return RedirectToPage("NewToDoList");
      }

      public void OnPostAddEntry()
      {
         ArrayItems.Add(Item);
      }

      public void OnPostRemoveEntry(int index)
      {
         ArrayItems.RemoveAt(index);
      }
   }
}
