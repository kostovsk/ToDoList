using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ToDoListController : ControllerBase
   {
      private readonly ApplicationDbContext _db;

      public ToDoListController(ApplicationDbContext db)
      {
         _db = db;
      }

      [HttpGet]
      public async Task<ActionResult<IEnumerable<ToDoList>>> GetToDoList()
      {
         return await _db.ToDoList.ToListAsync();
      }

      [HttpGet("{id}")]
      public async Task<ActionResult<ToDoList>> GetToDoListSingle(int id)
      {
         var todoList = await _db.ToDoList.FindAsync(id);

         if (todoList == null)
         {
            return NotFound();
         }

         return todoList;
      }

      [HttpPost]
      public async Task<ActionResult<ToDoList>> AddToDoList(ToDoList todoList)
      {
         todoList.DATE_CREATED = DateTime.Now;

         _db.ToDoList.Add(todoList);
         await _db.SaveChangesAsync();

         return CreatedAtAction(
            nameof(GetToDoListSingle),
            new { id = todoList.LIST_ID },
            todoList);
      }
   }
}
