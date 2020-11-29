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
      public ListModel ListModel { get; set; }

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

         ListModel.Date = DateTime.Now;

         _db.ListModel.Add(ListModel);
         await _db.SaveChangesAsync();

         return RedirectToPage("Index");
      }

      public void OnPostAddEntry()
      {
         ListModel.ListItems.Add(new Item());
      }

      public void OnPostRemoveEntry(int index)
      {
         ListModel.ListItems.RemoveAt(index);
      }
   }
}
