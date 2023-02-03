using System;

namespace DapperLearning.Exceptions
{
    internal class UserAlreadyInDatabaseException : Exception
    {
        public UserAlreadyInDatabaseException(string message) : base(message)
        {

        }
    }
}
