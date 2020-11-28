using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Pages.ListTypes
{
   public class IndexModel : PageModel
   {

      private readonly ApplicationDbContext _db;

      public IndexModel(ApplicationDbContext db)
      {
         _db = db;
      }

      public IList<ListType> ListType { get; set; }

      public async Task<IActionResult> OnGet()
      {
         ListType = await _db.ListType.ToListAsync();
         return Page();
      }
   }
}
