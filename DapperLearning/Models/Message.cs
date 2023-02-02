using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLearning
{
    internal class Message
    {
        public Guid Id { get; set; }
        public String Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
