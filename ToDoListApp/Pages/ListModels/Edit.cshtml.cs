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
      public IList<Items> ArrayItems { get; set; }
      [BindProperty]
      public Items Items { get; set; }
      [BindProperty]
      public List<int> AreChecked { get; set; }

      public async Task<IActionResult> OnGet(int? id)
      {
         //gets the id from the Query String: https://localhost:44306/ListModels/Edit?Id=1

         /*
          TODO: 
            check for null, if null then redirect back to Index page with the ItemsList, 
            else convert 'idFromQueryString' to int and use the _db to find the item
          */
         if (id == null)
         {
            string idFromQueryString = Request.Query["Id"];

            if (String.IsNullOrEmpty(idFromQueryString))
            {
               return RedirectToPage("NewToDoList");
            }
         }

         ArrayToDoList = await _db.ToDoList.ToListAsync();
         ArrayItems = await _db.Items.ToListAsync();

         return Page();
      }

      public async Task<IActionResult> OnPostAsync()
      {
         if (!ModelState.IsValid)
         {
            return Page();
         }

         _db.Items.Add(Items);
         await _db.SaveChangesAsync();

         var listId = Items.LIST_ID;

         return RedirectToPage("Edit", new { id = listId });
      }

      public async Task<IActionResult> OnPostRemove()
      {
         int listId = -1;

         for(int i = 0; i < AreChecked.Count; i++)
         {
            foreach (var item in _db.Items)
            {
               if(item.ITEM_ID == AreChecked[i])
               {
                  listId = item.LIST_ID;
                  _db.Items.Remove(item);
               }
            }
         }

         await _db.SaveChangesAsync();
         return RedirectToPage("Edit", new { id = listId });
      }
   }
}
