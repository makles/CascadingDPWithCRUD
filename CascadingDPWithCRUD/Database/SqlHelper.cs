using System.Data.SqlClient;

namespace CascadingDPWithCRUD.Database
{
    public class SqlHelper
    {
        public static string? DefaultConnection;

        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(DefaultConnection);
                return connection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
