using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLearning
{
    internal class PostMessage
    {
        public Guid Id { get; set; }   
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public Guid MessageId { get; set; }
    }
}
