using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uCookApp.Interfaces
{
    public interface IMapReader<TItem>
    {
        TItem MapReader(SqlDataReader reader);
        TItem ReturnNotFound();
        TItem ReturnError(string ex);
    }
}
