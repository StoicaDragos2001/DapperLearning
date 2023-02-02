using Dapper;
using DapperLearning.Constants;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DapperLearning
{
    internal static class Queries
    {
        public static void ExposeUsers(SqlConnection connection)
        {
            Console.WriteLine(MessageConstants.FirstExercise);
            string sqlQuery = "SELECT * FROM Users";
            var usersList = (List<User>)connection.Query<User>(sqlQuery);
            foreach (User user in usersList)
            {
                Console.WriteLine(user.FirstName);
            }
            Console.WriteLine();
        }

        public static void GetPostsOfUser(string userEmail, SqlConnection connection)
        {
            Console.WriteLine(MessageConstants.SecondExercise);
            string sqlQuery = String.Format(@"SELECT *
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

        public static void InsertUser(String FirstName, String LastName, String PhoneNumber, String Email, SqlConnection connection)
        {
            Console.WriteLine(MessageConstants.ThirdExercise);
            var user = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Email = Email
            };
            string sqlQuery = "INSERT INTO Users (FirstName, LastName, PhoneNumber, Email) VALUES(@FirstName, @LastName, @PhoneNumber, @Email)";
            connection.Execute(sqlQuery, user);
            Console.WriteLine();
        }
    }
}
