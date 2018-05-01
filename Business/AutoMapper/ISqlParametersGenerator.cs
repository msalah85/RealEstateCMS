using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public interface ISqlParametersGenerator
    {
        List<SqlParameter> Generate<T>(T model);

        List<SqlParameter> GenerateInsertUpdateParameters<T>(T model);
    }
}
