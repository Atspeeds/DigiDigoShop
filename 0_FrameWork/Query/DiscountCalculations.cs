using _0_FrameWork.Application;
using System;

namespace _0_FrameWork.Query
{
    public class DiscountCalculations
    {
        public static double CalculationDiscountPercentage(double price, int discountRate)
        {
            var result = Math.Round(price-(price * discountRate) / 100);
            return result;
        }
    }
}
