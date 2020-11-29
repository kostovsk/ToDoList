using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApp.Models
{
   public class ListModel
   {
      public int Id { get; set; }
      [Required]
      public string Name { get; set; }
      public DateTime Date { get; set; }
      public List<Item> ListItems { get; set; }

      public ListModel()
      {
         this.ListItems = new List<Item>();
      }
   }
}
