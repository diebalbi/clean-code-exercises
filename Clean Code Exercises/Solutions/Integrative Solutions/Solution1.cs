namespace Solutions.Integrative_Solutions
{
    //- Renamed Methods and Variables: Changed Contar to CalculateAverageOfOddEndingNumbers for clarity. Renamed variables to be more descriptive.
    //- Separated Concerns: Introduced a separate IsOddEnding method to check if a number ends in an odd digit,
    // improving readability and separation of logic.
    //- Improved Error Handling: Removed the try-catch block for general exceptions.
    // Introduced a check using Any() to handle the scenario where no numbers match the condition, providing a clear message.
    //- Used LINQ: Leveraged LINQ to filter the list of numbers and calculate the average in a clean, concise manner.

    public class Solution1
    {
        public static void Main()
        {
            var numbers = new List<int> { 2, 4, 6 };
            var averageOfOddEndingNumbers = CalculateAverageOfOddEndingNumbers(numbers);

            Console.WriteLine("Average of numbers ending in an odd digit: " + averageOfOddEndingNumbers);
        }

        private static double CalculateAverageOfOddEndingNumbers(List<int> numbers)
        {
            var oddEndingNumbers = numbers.Where(IsOddEnding).ToList();

            if (!oddEndingNumbers.Any())
            {
                Console.WriteLine("No numbers with an odd ending found.");
                return 0;
            }

            return oddEndingNumbers.Average();
        }

        private static bool IsOddEnding(int number)
        {
            var lastDigit = number % 10;
            return lastDigit == 1 || lastDigit == 3 || lastDigit == 5 || lastDigit == 7 || lastDigit == 9;
        }
    }

}
