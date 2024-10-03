namespace Exercises.Integrative_Exercise
{
    internal class Exercise5
    {
        // You are given a method Calculate that processes a list of integers to identify numbers divisible by 3 and 5.
        // The method collects these numbers into separate lists, sums them, and then calculates an average.
        // Additionally, it throws an exception if there are no numbers divisible by 3 or 5.
        // While the method works, there are several aspects that could be improved to adhere to Clean Code principles.
        // Analyze the code to identify potential improvements in naming, error handling, control flow, and overall structure.
        public static double Calculate(List<int> nums)
        {
            List<int> div3Int = new List<int>();
            List<int> div5Int = new List<int>();
            int sum3NumInt = 0;
            int sum5NumInt = 0;

            for (int indexOfNumbers = 0; indexOfNumbers < nums.Count; indexOfNumbers++)
            {
                int num = nums[indexOfNumbers];

                if (num % 3 == 0)
                {
                    div3Int.Add(num);
                    sum3NumInt += num;
                }

                if (num % 5 == 0)
                {
                    div5Int.Add(num);
                    sum5NumInt += num;
                }
            }

            if (div3Int.Count == 0 || div5Int.Count == 0)
            {
                throw new Exception("The list does not contain numbers divisible by 3 and 5");
            }

            double average = (sum3NumInt / (double)div3Int.Count + sum5NumInt / (double)div5Int.Count);
            return average;
        }

    }
}
