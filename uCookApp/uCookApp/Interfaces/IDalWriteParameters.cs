using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uCookApp.Interfaces
{
    public interface IDalWriteParameters<TItem>
    {
        string GenerateParameters(TItem obj);
        string UpdateParameters(TItem obj);
    }
}
