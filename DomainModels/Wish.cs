using System;

namespace DomainModels
{
    public class Wish
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CompletedAt { get; set; }
    }
}
