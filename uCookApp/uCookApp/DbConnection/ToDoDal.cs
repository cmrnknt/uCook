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

        public bool CreateItem(ToDo obj)
        {
            return _baseDal.WriteToDB(obj);
        }

        public void DeleteItem(int id)
        {
            _baseDal.MarkAsDeleted(id);
        }

        public bool UpdateItem(ToDo obj)
        {
            return _baseDal.WriteToDB(obj);
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