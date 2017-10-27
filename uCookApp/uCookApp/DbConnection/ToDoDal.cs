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

        public void CreateItem(ToDo obj)
        {
            _baseDal.WriteToDB(obj);
        }

        public void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public ToDo PutItem(int id)
        {
            throw new NotImplementedException();
        }

        public ToDo FetchItem(int id)
        {
            var dbReader = _baseDal.ReadFromDB(id);
            dbReader.Read();
            if (dbReader.HasRows)
            {
                return new ToDo()
                {
                    Id = dbReader.GetInt32(0),
                    Summary = dbReader.GetString(1),
                    Title = dbReader.GetString(2),
                    DateCompleted = dbReader.GetDateTime(3)
                };
            }
            else
            {
                return null;
            }

        }
    }
}