using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uCookApp.Interfaces;
using uCookApp.Models;

namespace uCookApp.DbConnection
{
    public class ToDoItemWriteParameters : IDalWriteParameters<ToDo>
    {
        public string GenerateParameters(ToDo obj)
        {
            if(obj == null)
            {
                //I would log ERROR level message here. This should never be null and means a dev has changed types/code that they shouldn't have.
                throw new InvalidCastException();
            }
            return string.Format("({0},{1},{2})", obj.Title, obj.Summary, obj.DateCompleted);
        }
    }
}