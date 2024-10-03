namespace Solutions.Integrative_Solutions
{
    internal class Solution5
    {
        //- Method Extraction: Extracted specific parts of the logic into their own methods to handle different responsibilities,
        // making the code more modular and readable
        //- Higher Abstraction in Main Method: The main method, CalculateAverageOfDivisibleNumbers, now operates at a higher level of abstraction,
        // focusing on the sequence of operations rather than the specific implementation details.
        // This makes the method easier to read and understand.
        //- Reusable Methods: By extracting methods like GetDivisibleNumbers and CalculateAverage, we can now reuse these methods in
        // other parts of the application if needed, following the DRY(Don't Repeat Yourself) principle.
        //- Separation of Concerns: Each method now has a single, clear responsibility.
        public static double CalculateAverageOfDivisibleNumbers(List<int> numbers)
        {
            var divisibleBy3 = GetDivisibleNumbers(numbers, 3);
            var divisibleBy5 = GetDivisibleNumbers(numbers, 5);

            ValidateDivisibleNumbers(divisibleBy3, divisibleBy5);

            double average = CalculateAverage(divisibleBy3) + CalculateAverage(divisibleBy5);
            return average;
        }

        private static List<int> GetDivisibleNumbers(List<int> numbers, int divisor)
        {
            var divisibleNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (number % divisor == 0)
                {
                    divisibleNumbers.Add(number);
                }
            }
            return divisibleNumbers;
        }

        private static void ValidateDivisibleNumbers(List<int> divisibleBy3, List<int> divisibleBy5)
        {
            if (!divisibleBy3.Any() || !divisibleBy5.Any())
            {
                throw new InvalidOperationException("The list must contain numbers divisible by both 3 and 5.");
            }
        }

        private static double CalculateAverage(List<int> numbers)
        {
            int sum = numbers.Sum();
            return sum / (double)numbers.Count;
        }

    }
}
