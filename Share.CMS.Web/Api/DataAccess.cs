using Share.CMS.Web.Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Share.CMS.Web.Api
{
    public class DataAccess
    {
        public static SqlCommand CreateCommand()
        {
            string connnectionString = Config.connString;
            var connection = new SqlConnection(connnectionString);
            var command = connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        public static SqlCommand CreateCommandText()
        {
            string connnectionString = Config.connString;
            var connection = new SqlConnection(connnectionString);
            var command = connection.CreateCommand();

            command.CommandType = CommandType.Text;
            return command;
        }
    }
}