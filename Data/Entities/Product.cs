using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoePortal_ECommerce.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string ShoeTitle { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string Colour { get; set; }
        public string Description { get; set; }
    }
}
