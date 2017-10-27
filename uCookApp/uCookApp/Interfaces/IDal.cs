using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uCookApp.Models;

namespace uCookApp.Interfaces
{
    public interface IDal<TItem>
    {
        TItem FetchItem(int id);
        void DeleteItem(int id);
        TItem PutItem(int id);
        void CreateItem(TItem obj);
    }
}
