using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoListApp.Models;

namespace ToDoListApp.Data
{
   public class ApplicationDbContext : IdentityDbContext
   {

      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
      {
      }

      public DbSet<ListModel> ListModel { get; set; }
      public DbSet<ToDoList> ToDoList { get; set; }
      public DbSet<Items> Items { get; set; }
   }
}
