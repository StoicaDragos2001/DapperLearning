using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DapperLearning
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperLearning.Properties.Settings.SQLDatabase"].ConnectionString);

            using (connection)
            {
                await connection.OpenAsync();
                await Queries.GetUsersAsync(connection);
                await Queries.GetPostsAsync("hfulham0@mtv.com", connection);
                await Queries.InsertUserAsync("Brunhilde", "Paramore", "556-383-3458", "bparamore0@jigsy.com", connection);
                await Queries.GetUsersAsync(connection);

            }
        }
    }
}
