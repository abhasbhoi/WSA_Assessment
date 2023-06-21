using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFarmersMarket.Models
{
    internal class ProductOffer
    {
        public ProductCode? ProductCode { get; set; }
        public OfferCode? OfferCode { get; set; }
        public decimal Price { get; set; }
    }
}
