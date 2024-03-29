﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
   public class ListType
   {
      public int Id { get; set; }
      [Required]
      public string Name { get; set; }
      public DateTime Date { get; set; }
      public List<Item> ListItems { get; set; }

      public ListType()
      {
         this.ListItems = new List<Item>();
      }
   }
}
