﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz.Tests
{
    internal class PotterShop
    {
        private const int PricePerUnit = 8;

        internal static double CashOut(int[] basket)
        {
            var priceForDuplicates = HowManyDuplicates(basket) * PricePerUnit;
            var priceForDistinct = HowManyDistinct(basket)
                * PricePerUnit
                * PriceAfterDiscountForDistinctBooks(HowManyDistinct(basket));

            return priceForDuplicates + priceForDistinct;
        }

        private static double PriceAfterDiscountForDistinctBooks(int howMany)
        {
            return howMany switch
            {
                1 => 1.00,
                2 => 0.95,
                3 => 0.90,
                4 => 0.80,
                5 => 0.75,
                _ => throw new ArgumentException("No hay más de cinco chaval.")
            };
        }

        private static int HowManyDuplicates(int[] basket)
        {
            return basket.Length - basket.Distinct().Count();
        }

        private static int HowManyDistinct(int[] basket)
        {
            return basket.Distinct().Count();
        }
    }
}