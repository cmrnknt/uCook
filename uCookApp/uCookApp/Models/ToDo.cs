﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uCookApp.Models
{
    public class ToDo : BaseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime DateCompleted { get; set; }

        public string ToJson()
        {
            //Replace with an actual ToJson method
            return String.Format("{0},{1},{2},{3}", Id, Title, Summary, DateCompleted);
        }
    }
}