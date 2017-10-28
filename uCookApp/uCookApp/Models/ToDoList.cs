using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uCookApp.Models
{
    public class ToDoList : BaseItem
    {
        public List<ToDo> Items { get; set; }

        public List<string> ToJson()
        {
            return Items.Select(i => i.ToJson()).ToList();
        }
    }
}