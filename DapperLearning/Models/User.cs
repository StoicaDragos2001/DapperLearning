using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLearning
{
    internal class User
    {
        public User()
        {
            Posts = new List<Post>();
        }

        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public List<Post> Posts { get; set; }
    }
}
