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
   public class ViewModel : PageModel
   {
      private readonly ApplicationDbContext _db;
      [BindProperty]
      public ListModel ListModel { get; set; }

      public ViewModel(ApplicationDbContext db)
      {
         _db = db;
      }

      public IActionResult OnGet()
      {
         return Page();
      }

      public Item OnGetEntry(int index)
      {
         return ListModel.ListItems[index];
      }

   }
}
