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
    public class EditModel : PageModel
    {
      private readonly ApplicationDbContext _db;

      public EditModel(ApplicationDbContext db)
      {
         _db = db;
      }
      public IList<ToDoList> ArrayToDoList { get; set; }



      public async Task<IActionResult> OnGet()
      {

         //gets the id from the Query String: https://localhost:44306/ListModels/Edit?Id=1

         string idFromQueryString = Request.Query["Id"];
         /*
          TODO: 
            check for null, if null then redirect back to Index page with the ItemsList, 
            else convert 'idFromQueryString' to int and use the _db to find the item
          */
         if (String.IsNullOrEmpty(idFromQueryString))
         {
            return RedirectToPage("Index");
         }

         ArrayToDoList = await _db.ToDoList.ToListAsync();
         
         return Page();
      }
   }
}
