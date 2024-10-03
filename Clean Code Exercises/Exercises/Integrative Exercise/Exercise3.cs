namespace Exercises.Integrative_Exercise
{
    internal class Exercise3
    {
        // The CalculateDiscount method uses magic numbers, and the logic could be extracted for better clarity and flexibility.
        public class DiscountCalculator
        {
            public double CalculateDiscount(double totalAmount)
            {
                if (totalAmount > 1000)
                {
                    return totalAmount * 0.1;
                }
                else if (totalAmount > 500)
                {
                    return totalAmount * 0.05;
                }
                else
                {
                    return 0;
                }
            }
        }

    }
}
