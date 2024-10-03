namespace Solutions.Integrative_Solutions
{
    internal class Solution3
    {
        //- Magic Numbers: Replaced magic numbers with constants (HIGH_DISCOUNT_RATE, MEDIUM_DISCOUNT_RATE, HIGH_DISCOUNT_THRESHOLD, and
        // MEDIUM_DISCOUNT_THRESHOLD) for better clarity and flexibility.
        //- Simplified Control Flow: Removed the else if statement by using two separate if statements, improving readability.
        //- Clear Unit Tests: The updated code is more understandable, and the unit tests remain the same but are now easier to interpret.
        public class DiscountCalculator
        {
            private const double HIGH_DISCOUNT_RATE = 0.1;
            private const double MEDIUM_DISCOUNT_RATE = 0.05;
            private const double HIGH_DISCOUNT_THRESHOLD = 1000;
            private const double MEDIUM_DISCOUNT_THRESHOLD = 500;

            public static double CalculateDiscount(double totalAmount)
            {
                if (totalAmount > HIGH_DISCOUNT_THRESHOLD)
                {
                    return totalAmount * HIGH_DISCOUNT_RATE;
                }

                if (totalAmount > MEDIUM_DISCOUNT_THRESHOLD)
                {
                    return totalAmount * MEDIUM_DISCOUNT_RATE;
                }

                return 0;
            }
        }
    }
}
