using System;
using System.Collections.Generic;

namespace DapperLearning
{
    internal class User
    {
        public User()
        {
            Posts = new List<Post>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Post> Posts { get; set; }
    }
}
