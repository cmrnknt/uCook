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
        TItem ReadFromDB(int id);
        List<TItem> ReadAllRowsFromDB();
        int WriteToDB(TItem obj);
        int UpdateRowInDB(TItem obj);
        void MarkAsDeleted(int id);

    }
}
