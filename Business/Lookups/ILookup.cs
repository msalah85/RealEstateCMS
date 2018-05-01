using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Lookups
{
    public interface ILookup
    {
        List<ItemValue> Get();
    }
}
