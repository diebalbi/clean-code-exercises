namespace Exercises
{
    internal class CommentLevel
    {
        //The following code contains a variable with a non-descriptive name and an added comment to explain its functionality. Improve the code
        public void Exercise1()
        {
            // Number of iterations
            int n = 5;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Iteration: " + i);
            }
        }

        //This code contains a method with a vague name and a comment explaining what it does.
        //There is also an exception that has a comment associated with it. Improve the code
        public void Exercise2()
        {
            try
            {
                int result = DoSomething(5, 0); // This method divides two numbers
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                // Handle divide by zero exception
                Console.WriteLine("Error: Division by zero is not allowed.");
            }
        }

        private int DoSomething(int a, int b)
        {
            return a / b;
        }


        //This code checks if a number is prime. Some variable names are not clear, and there is a comment explaining part of the code.
        //Improve the code.
        public void Exercise3()
        {
            int num = 29;
            bool isPrime = CheckPrime(num); // Check if the number is prime
            Console.WriteLine(num + " is prime: " + isPrime);
        }

        private bool CheckPrime(int n)
        {
            if (n <= 1)
            {
                return false;
            }

            for (int i = 2; i < n; i++)
            {
                // If n is divisible by any number between 2 and n-1, it's not prime
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }



        //This code checks if a given email is valid using a regular expression. It includes a comment explaining the regex pattern.
        //Improve the names and remove comments as needed
        public void Exercise4()
        {
            string input = "test@example.com";
            bool isValid = Check(input); // Checks if input is a valid email
            Console.WriteLine("Is valid email: " + isValid);
        }

        private bool Check(string email)
        {
            // Regex pattern to match a valid email address
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
        }



        //The code sums a list of numbers and contains both unnecessary and useful comments. Improve the names and remove comments as needed.
        public void Exercise5()
        {
            // Create a list of numbers
            List<int> nums = new List<int> { 1, 2, 3, 4, 5 };

            // Initialize sum to zero
            int s = 0;

            // Loop through the list
            foreach (int num in nums)
            {
                s += num; // Add each number to sum
            }

            // Print the sum
            Console.WriteLine("Sum: " + s);

            // TODO: Add error handling for an empty list
        }

    }
}
