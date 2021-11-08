using System.Collections.Generic;

namespace DomainModels
{
    public class Wishlist
    {
        public List<Wish> Wishes { get; set; } = new List<Wish>(0);
    }
}
