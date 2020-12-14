using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models
{
   public class ToDoList
   {

      [Key]
      public int LIST_ID { get; set; }
      [Required]
      public string NAME { get; set; }
      public DateTime DATE_CREATED { get; set; }
   }
}