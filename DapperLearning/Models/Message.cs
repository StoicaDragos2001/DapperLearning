using System;

namespace DapperLearning
{
    internal class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
