using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uCookApp.Models;

namespace uCookApp.Interfaces
{
    public interface IBaseDal<TItem>
    {
        SqlDataReader ReadFromDB(int id);
        SqlDataReader ReadAllRowsFromDB();
        void WriteToDB(TItem obj);
        void MarkAsDeleted(int id);

    }
}
