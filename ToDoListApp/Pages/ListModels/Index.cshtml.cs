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
   public class IndexModel : PageModel
   {
      private readonly ApplicationDbContext _db;

      public IndexModel(ApplicationDbContext db)
      {
         _db = db;
      }

      public IList<ListModel> ListModel { get; set; }

      public async Task<IActionResult> OnGet()
      {
         ListModel = await _db.ListModel.ToListAsync();
         return Page();
      }
   }
}
