using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uCookApp.Constants;
using uCookApp.Interfaces;
using uCookApp.Models;

namespace uCookApp.DbConnection
{
    public class ToDoDal : IDal<ToDo>
    {
        IBaseDal<ToDo> _baseDal;
        public ToDoDal(IBaseDal<ToDo> baseDal)
        {
            _baseDal = baseDal;
        }

        public ToDo CreateItem(ToDo obj)
        {
            //in a stored proc I would just make the one query to the db which returns the object that was created 
            //(or just gets the id of the object which can be riskier if the project grows).
            int createdId = _baseDal.WriteToDB(obj);
            if (createdId > 0)
            {
                return FetchItem(createdId);
            }
            return null;
        }

        public void DeleteItem(int id)
        {
            _baseDal.MarkAsDeleted(id);
        }

        public ToDo UpdateItem(ToDo obj)
        {
            int createdId = _baseDal.UpdateRowInDB(obj);
            if (createdId > 0)
            {
                return FetchItem(createdId);
            }
            return null;
        }

        public ToDo FetchItem(int id)
        {
            var mappedObject = _baseDal.ReadFromDB(id);
            if (mappedObject != null)
            {
                return mappedObject;
            }
            else
            {
                return null;
            }

        }

        public List<ToDo> FetchAllItems()
        {
            return _baseDal.ReadAllRowsFromDB();
        }
    }
}