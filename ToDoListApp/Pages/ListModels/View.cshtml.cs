using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Pages.ListModels
{
   public class ViewModel : PageModel
   {
      private readonly ApplicationDbContext _db;
      
      public ViewModel(ApplicationDbContext db)
      {
         _db = db;
      }

      public ToDoList ToDoList { get; set; }
      public IList<Items> ArrayItems { get; set; }

      public async Task<IActionResult> OnGet(int? id)
      {
         if (id == null)
         {
            string idFromQueryString = Request.Query["Id"];

            if (String.IsNullOrEmpty(idFromQueryString))
            {
               return RedirectToPage("NewToDoList");
            }
         }

         ToDoList = _db.ToDoList
            .Single(x => x.LIST_ID == id);

         if (ToDoList == null)
         {
            return RedirectToPage("NewToDoList");
         }

         ArrayItems = await _db.Items
            .Where(n => n.LIST_ID == id)
            .ToListAsync();

         return Page();
      }

   }
}
