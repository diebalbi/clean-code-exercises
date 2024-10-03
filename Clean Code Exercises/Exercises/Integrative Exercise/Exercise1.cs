namespace Exercises.Integrative_Exercise
{
    // The Count method processes a list of numbers to sum only those that end in an odd digit and then calculates the average.
    // However, the code has multiple Clean Code violations, including unclear naming, poor error handling, and an overly complex structure.

    public class Exercise1
    {
        public static void Main()
        {
            var nums = new List<int> { 2, 4, 6 };
            var result = Count(nums);

            Console.WriteLine("Sum of numbers: " + result);
        }

        private static int Count(List<int> nums)
        {
            int result = 0;
            int cnt = 0;

            try
            {
                foreach (var n in nums)
                {
                    if (n.ToString().Last() == '1' || n.ToString().Last() == '3' || n.ToString().Last() == '5' ||
                        n.ToString().Last() == '7' || n.ToString().Last() == '9')
                    {
                        result += n;
                        ++cnt;
                    }
                }
                result = result / cnt;
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(DivideByZeroException))
                    return 0;
            }

            return result;
        }
    }
}
