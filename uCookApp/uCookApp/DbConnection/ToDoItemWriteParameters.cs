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
            if (obj == null)
            {
                //I would log ERROR level message here. This should never be null and means a dev has changed types/code that they shouldn't have.
                throw new InvalidCastException();
            }
            return string.Format("(Title, Summary, DateCompleted, IsDeleted) VALUES ('{0}','{1}','{2}', 0)", obj.Title, obj.Summary, obj.DateCompleted);
        }

        public string UpdateParameters(ToDo obj)
        {
            if (obj == null || obj.Id == 0)
            {
                //I would log ERROR level message here. This should never be null and means a dev has changed types/code that they shouldn't have.
                throw new InvalidCastException();
            }
            return string.Format("Title = '{0}', SUmmary = '{1}', DateCompleted = '{2}' WHERE ID = {3}", obj.Title, obj.Summary, obj.DateCompleted, obj.Id);
        }
    }
}