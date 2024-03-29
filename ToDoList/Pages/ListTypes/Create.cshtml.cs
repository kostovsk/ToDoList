using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Pages.ListTypes
{
   public class CreateModel : PageModel
   {
      private readonly ApplicationDbContext _db;
      [BindProperty]
      public ListType ListType { get; set; }

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

         ListType.Date = DateTime.Now;

         //var todo = new ListType
         //{
         //   Name = "Test list 3",
         //   Date = DateTime.Now,
         //   ListItems = new List<Item>
         //   {
         //      new Item { ItemEntry = "Homework"},
         //      new Item { ItemEntry = "Excercise" },
         //      new Item { ItemEntry = "Eat" }
         //   }
         //};

         _db.ListType.Add(ListType);
         await _db.SaveChangesAsync();

         return RedirectToPage("Index");
      }
   }
}
