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

      public IList<ToDoList> ArrayToDoList { get; set; }
      public IList<Items> ArrayItems { get; set; }

      public async Task<IActionResult> OnGet()
      {
         string idFromQueryString = Request.Query["Id"];

         if (String.IsNullOrEmpty(idFromQueryString))
         {
            return RedirectToPage("Index");
         }

         ArrayToDoList = await _db.ToDoList.ToListAsync();
         ArrayItems = await _db.Items.ToArrayAsync();

         return Page();
      }

   }
}
