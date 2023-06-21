using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFarmersMarket.Models
{
    internal class Product
    {
        public ProductCode ProductCode { get; set; }
        public ProductName Name { get; set; }
        public decimal Price { get; set; }
    }
}
