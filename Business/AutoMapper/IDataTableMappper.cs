using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public interface IDataTableMappper<T>
    {
        List<T> ToList(DataTable dataTable);
    }
}
