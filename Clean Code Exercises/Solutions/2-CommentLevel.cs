using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    internal class CommentLevel
    {
        // Improvement: Replaced vague variable name with a descriptive one, making the comment unnecessary.
        public void Exercise1()
        {
            int numberOfIterations = 5;
        
            for (int iteration = 0; iteration < numberOfIterations; iteration++)
            {
                Console.WriteLine("Iteration: " + iteration);
            }
        }
        
        // Improvement: Updated method and variable names for clarity, making explanatory comments redundant.
        // Handled divide by zero exception specifically.
        public void Exercise2()
        {
            try
            {
                int divisionResult = DivideNumbers(5, 0);
                Console.WriteLine(divisionResult);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
            }
        }
        
        private int DivideNumbers(int dividend, int divisor)
        {
            return dividend / divisor;
        }
        
        // Improvement: Refined method and variable names, removing the need for explanatory comments.
        public void Exercise3()
        {
            int numberToCheck = 29;
            bool isPrime = IsPrime(numberToCheck);
            Console.WriteLine($"{numberToCheck} is prime: {isPrime}");
        }
        
        private bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }
        
            for (int divisor = 2; divisor < number; divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }
        
        // Improvement: Clarified method names and variables, removing redundant comments.
        public void Exercise4()
        {
            string emailToValidate = "test@example.com";
            bool isEmailValid = IsValidEmail(emailToValidate);
            Console.WriteLine("Is valid email: " + isEmailValid);
        }
        
        private bool IsValidEmail(string email)
        {
            // Regex pattern to match a valid email address
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
        }
        
        // Improvement: Simplified code by using clear names. Retained the useful TODO comment.
        public void Exercise5()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            int totalSum = 0;
        
            foreach (int number in numbers)
            {
                totalSum += number;
            }
        
            Console.WriteLine("Sum: " + totalSum);
        
            // TODO: Add error handling for an empty list
        }
    }
}
