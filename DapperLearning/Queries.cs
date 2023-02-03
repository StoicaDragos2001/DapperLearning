using Dapper;
using DapperLearning.Constants;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DapperLearning
{
    internal static class Queries
    {
        public async static Task GetUsersAsync(SqlConnection connection)
        {
            Console.WriteLine(MessageConstants.FirstExercise);
            var sqlQuery = "SELECT * FROM Users";
            var users = connection.Query<User>(sqlQuery);
            foreach (User user in users)
            {
                Console.WriteLine(user.FirstName);
            }
            Console.WriteLine();
        }

        public async static Task GetPostsAsync(string userEmail, SqlConnection connection)
        {
            Console.WriteLine(MessageConstants.SecondExercise);
            var sqlQuery = String.Format(@"SELECT *
                                FROM Posts p
                                JOIN Users u ON p.UserId = u.Id
                                WHERE u.Email = '{0}' AND
                                p.CreatedDate > '1/1/2023'
                                ORDER BY p.CreatedDate ASC", userEmail);
            var queryResult = connection.Query<Post, User, Post>(
                sqlQuery,
                (post, user) =>
                {
                    post.User = user;
                    return post;
                }
                );
            foreach (var row in queryResult)
            {
                Console.WriteLine(row.CreatedDate);
                Console.WriteLine(row.Content);
            }
            Console.WriteLine();
        }

        public async static Task InsertUserAsync(string FirstName, string LastName, string PhoneNumber, string Email, SqlConnection connection)
        {
            Console.WriteLine(MessageConstants.ThirdExercise);
            var user = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Email = Email
            };
            var exists = connection.ExecuteScalar<bool>("SELECT COUNT(1) FROM Users WHERE Email = @Email", new {Email});
            if(exists)
            {
                throw new Exceptions.UserAlreadyInDatabaseException("This user email already exists.");
            }
            else
            {
                var sqlQuery = "INSERT INTO Users (FirstName, LastName, PhoneNumber, Email) VALUES(@FirstName, @LastName, @PhoneNumber, @Email)";
                connection.Execute(sqlQuery, user);
            }
            Console.WriteLine();
        }
    }
}
