using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApp.Models
{
   public class Items
   {
      [Key]
      public int ITEM_ID { get; set; }
      public int LIST_ID { get; set; }
      [Required]
      public string ITEM { get; set; }
   }
}
