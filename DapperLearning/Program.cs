using System.Data.SqlClient;
using System.Configuration;

namespace DapperLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperLearning.Properties.Settings.SQLDatabase"].ConnectionString);

            using (connection)
            {
                connection.Open();
                Queries.ExposeUsers(connection);
                Queries.GetPostsOfUser("hfulham0@mtv.com", connection);
                Queries.InsertUser("Brunhilde", "Paramore", "556-383-3458", "bparamore0@jigsy.com", connection);
                Queries.ExposeUsers(connection);
            }
        }
    }
}