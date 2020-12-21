using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Models;

namespace ToDoListApp.Data
{
   public class ListDbContext : DbContext
   {
      public ListDbContext()
      {

      }

      public DbSet<ToDoList> ToDoList { get; set; }
      public DbSet<Items> Items { get; set; }
   }
}
