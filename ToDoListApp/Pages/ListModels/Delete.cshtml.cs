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
   public class DeleteModel : PageModel
   {
      private readonly ApplicationDbContext _db;

      public DeleteModel(ApplicationDbContext db)
      {
         _db = db;
      }

      public IList<ToDoList> ArrayToDoList { get; set; }
      public IList<Items> ArrayItems { get; set; }


      public async Task<IActionResult> OnGet(int? id)
      {
         string idFromQueryString = Request.Query["Id"];

         var listId = Int32.Parse(idFromQueryString);

         foreach (var item in _db.ToDoList)
         {
            if (item.LIST_ID == listId)
            {
               _db.ToDoList.Remove(item);
            }
         }

         //_db.ToDoList.Remove(new ToDoList() { LIST_ID = listId });
         await _db.SaveChangesAsync();

         return RedirectToPage("NewToDoList");
      }
   }
}
