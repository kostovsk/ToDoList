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

      public ToDoList ToDoList { get; set; }
      public IList<ToDoList> ToDoListAll { get; set; }
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

         ToDoListAll = await _db.ToDoList.ToListAsync();

         ToDoList = _db.ToDoList
            .Single(x => x.LIST_ID == id);

         if(ToDoList == null)
         {
            return RedirectToPage("NewToDoList");
         }
         
         ArrayItems = await _db.Items
            .Where(n => n.LIST_ID == id)
            .ToListAsync();

         return Page();
      }

      public async Task<IActionResult> OnPostAsync()
      {
         var listId = Items.LIST_ID;

         if (!ModelState.IsValid)
         {
            return RedirectToPage("Edit", new { id = listId });
         }

         _db.Items.Add(Items);
         await _db.SaveChangesAsync();

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

      public async Task<IActionResult> OnPostCopyTo()
      {
         //var myId = Request.Form["dropdownform"];

         for (int i = 0; i < AreChecked.Count; i++)
         {
            foreach (var item in _db.Items)
            {
               if (item.ITEM_ID == AreChecked[i])
               {
                  Items TempItem = new Items();
                  TempItem.ITEM = item.ITEM;
                  TempItem.LIST_ID = 2016;
                  _db.Items.Add(TempItem);
               }
            }
         }

         await _db.SaveChangesAsync();
         return RedirectToPage("NewToDoList");
      }
   }
}
