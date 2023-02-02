using System;

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
