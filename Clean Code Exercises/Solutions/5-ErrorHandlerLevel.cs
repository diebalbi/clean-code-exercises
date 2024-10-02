namespace Solutions
{
    internal class ErrorHandlerLevel
    {
        //Improvement:
        //- Specific Exceptions: Catching DivideByZeroException instead of the generic Exception.
        //- Meaningful Names: Changed method name to DivideNumbers and variable names to numerator and denominator.
        public void Exercise1()
        {
            try
            {
                int result = DivideNumbers(10, 0);
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Cannot divide by zero: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid argument: " + ex.Message);
            }
        }

        private int DivideNumbers(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero.");
            }

            return numerator / denominator;
        }

        //Improvement:
        //- Specific Exceptions: Catching IndexOutOfRangeException.
        //- Fallback Catch: Added a fallback catch (Exception ex) to handle unforeseen errors.
        //- Error Message: Provides meaningful feedback instead of silencing the error.
        public void Exercise2()
        {
            try
            {
                int[] numbers = new int[5];
                Console.WriteLine(numbers[10]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Index out of range: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        //Improvement:
        //- Custom Exception: Introduced InvalidInputException to handle specific error cases.
        //- Remove Magic Numbers: Replaced the magic number -1 with a custom exception.
        //- Comment Removal: Removed the comment explaining the error and used an exception message instead.
        public void Exercise3()
        {
            try
            {
                int result = CalculateSquareRoot(-5);
                Console.WriteLine("Square root: " + result);
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private int CalculateSquareRoot(int number)
        {
            if (number < 0)
            {
                throw new InvalidInputException("Input cannot be negative for square root calculation.");
            }
            return (int)Math.Sqrt(number);
        }

        public class InvalidInputException : Exception
        {
            public InvalidInputException(string message) : base(message)
            {
            }
        }

        //Improvement:
        //- Code Extraction: Extracted the validation logic into a separate method(ValidateUser).
        //- Exception Handling: Used ArgumentException to handle validation errors, centralizing the error messages in one place and
        // simplifying the main method.
        //- Early Return: The use of exceptions allows the method to return immediately if an error is encountered, which helps in isolating the main logic.
        // Optional: can create an specific exception for User rules like UserException.
        public void Exercise4()
        {
            string username = "user123";
            string password = "pass123";

            try
            {
                ValidateUser(username, password);
                Console.WriteLine("User is valid.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Validation error: {ex.Message}");
            }
        }

        private void ValidateUser(string username, string password)
        {
            ValidateEmptyUsername(username);
            ValidateMinLengthUsername(username);
            VadaliteEmptyPassword(password);
            ValidateMinLengthPassword(password);
        }

        private static void ValidateEmptyUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username cannot be empty.");
            }
        }

        private static void ValidateMinLengthUsername(string username)
        {
            if (username.Length < 5)
            {
                throw new ArgumentException("Username must be at least 5 characters long.");
            }
        }

        private static void VadaliteEmptyPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be empty.");
            }
        }

        private static void ValidateMinLengthPassword(string password)
        {
            if (password.Length < 6)
            {
                throw new ArgumentException("Password must be at least 6 characters long.");
            }
        }

        //Improvement:
        //- Code Extraction: Moved the validation logic to a separate method (ValidateOrder).
        //- Guard Clauses: Used guard clauses to immediately throw exceptions if any conditions are not met, reducing nesting.
        //- Exception Handling: Creat custom exception (OrderException) for validation errors to improve the clarity of error handling.
        public void Exercise6(Order order)
        {
            try
            {
                ValidateOrder(order);
                double total = order.Quantity * order.Price;
                Console.WriteLine($"Order total: {total}");
            }
            catch (OrderException ex)
            {
                Console.WriteLine($"Order error: {ex.Message}");
            }
        }

        private void ValidateOrder(Order order)
        {
            ValidateNullOrder(order);
            ValidateQuantity(order);
            ValidatePrice(order);
        }

        private static void ValidateNullOrder(Order order)
        {
            if (order == null)
            {
                throw new OrderException("Order cannot be null.");
            }
        }

        private static void ValidateQuantity(Order order)
        {
            if (order.Quantity <= 0)
            {
                throw new OrderException("Quantity must be greater than zero.");
            }
        }

        private static void ValidatePrice(Order order)
        {
            if (order.Price <= 0)
            {
                throw new OrderException("Price must be greater than zero.");
            }
        }

        public class Order
        {
            public int Quantity { get; set; }
            public double Price { get; set; }
        }

        public class OrderException : Exception
        {
            public OrderException(string message) : base(message)
            {
            }
        }

        //Improvement:
        //- Exception Handling: In the refactored code, exceptions are used in place of return-value checks (null or false).
        // This allows us to simplify the main method by removing the need for multiple if statements after each method call.
        //- Simplified Flow: The main method(Exercise8) now sequentially calls each method without checks between them, relying on
        // a single try-catch block to handle all possible errors.
        //- Centralized Error Handling: Using a single catch block at the end centralizes error handling and provides a clear way
        // to manage and log exceptions.
        public void Exercise8()
        {
            try
            {
                User user = FetchUser("user123");
                Account account = GetAccountDetails(user);
                ProcessTransaction(account, 500);

                Console.WriteLine("Transaction completed successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private User FetchUser(string username)
        {
            if (username != "user123")
            {
                throw new ArgumentException("User not found.");
            }

            return new User();
        }

        private Account GetAccountDetails(User user)
        {
            if (user == null)
            {
                throw new ArgumentException("Account details could not be retrieved.");
            }

            return new Account();
        }

        private void ProcessTransaction(Account account, double amount)
        {
            if (account == null)
            {
                throw new ArgumentException("Account not found.");
            }

            if (amount > account.Balance)
            {
                throw new ArgumentException("Insufficient balance.");
            }

            // Process transaction logic
        }


        public class User
        {
            public string Username { get; set; }
        }

        public class Account
        {
            public double Balance { get; set; }
        }
    }
}
