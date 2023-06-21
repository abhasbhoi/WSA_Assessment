using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TheFarmersMarket.Models;
using TheFarmersMarket.Operations.Contracts;

namespace TheFarmersMarket
{
    internal class PricingEngine : IPricingEngine
    {
        public PricingEngine()
        {

        }


        public List<ProductOffer> ApplyOffer(List<ProductOffer> productOffers)
        {
            int coffeeCounter = 0;
            int AppleCounter = 0;
            int ChaiCounter = 0;
            int OatmealCounter = 0;
            int MilkCounter = 0;

            // set counters and loadProductOffers
            List<ProductOffer> finalProductOffer = new List<ProductOffer>();
            foreach (var product in productOffers)
            {
                var result = product.ProductCode switch
                {
                    ProductCode.CH1 => ChaiCounter++,
                    ProductCode.AP1 => AppleCounter++,
                    ProductCode.CF1 => coffeeCounter++,
                    ProductCode.OM1 => OatmealCounter++,
                    ProductCode.MK1 => MilkCounter++
                };
                finalProductOffer.Add(product);
            }


            // Apply offers to cart

            //BOGO -- Buy-One-Get-One-Free Special on Coffee. (Unlimited)
            if (coffeeCounter >= 2)
            {
                int BOGOOfferCount = coffeeCounter / 2;
                while (BOGOOfferCount-- > 0)
                {
                    finalProductOffer.Add(new ProductOffer
                    {
                        OfferCode = OfferCode.BOGO,
                        Price = -11.23M
                    });
                }
            }

            // APPL -- If you buy 3 or more bags of Apples, the price drops to $4.50.
            if (AppleCounter >= 3)
            {
                while (AppleCounter-- > 0)
                {
                    finalProductOffer.Add(new ProductOffer
                    {
                        OfferCode = OfferCode.APPL,
                        Price = -1.50M
                    });
                }
            }

            // APOM -- Purchase a bag of Oatmeal and get 50% off a bag of Apples
            else if (AppleCounter < 3 && OatmealCounter > 1)
            {
                finalProductOffer.Add(new ProductOffer
                {
                    OfferCode = OfferCode.APOM,
                    Price = -3.00M
                });
            }

            // CHMK -- Purchase a box of Chai and get milk free. (Limit 1)
            if (ChaiCounter >= 1)
            {
                if (ChaiCounter > MilkCounter)
                {
                    while (ChaiCounter - MilkCounter++ > 0)
                    {
                        finalProductOffer.Add(new ProductOffer
                        {
                            ProductCode = ProductCode.MK1,
                            Price = 4.75M
                        });
                    }
                }
                while (ChaiCounter-- > 0)
                {
                    finalProductOffer.Add(new ProductOffer
                    {
                        OfferCode = OfferCode.CHMK,
                        Price = -4.75M
                    });
                }
            }

            return finalProductOffer;
        }
    }
}
