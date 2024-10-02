namespace Exercises
{
    internal class ErrorHandlerLevel
    {
        //The code below catches a generic exception, which can hide specific errors and make the code difficult to debug.
        //Improve the code
        public void Exercise1()
        {
            try
            {
                int result = Divide(10, 0);
                Console.WriteLine("Result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private int Divide(int a, int b)
        {
            return a / b;
        }

        //The following code contains an empty catch block, which is a bad practice as it silences potential errors.
        //Improve the code
        public void Exercise2()
        {
            try
            {
                int[] numbers = new int[5];
                Console.WriteLine(numbers[10]); // Index out of range
            }
            catch
            {
                // Do nothing
            }
        }

        //The code uses a magic number (-1) to indicate an error and contains an unnecessary comment explaining the error.
        //Improve the code
        public void Exercise3()
        {
            int result = CalculateSquareRoot(-5);
            if (result == -1)
            {
                // Invalid input
                Console.WriteLine("Invalid input for square root calculation.");
            }
            else
            {
                Console.WriteLine("Square root: " + result);
            }
        }

        private int CalculateSquareRoot(int number)
        {
            if (number < 0)
            {
                return -1; // Error indication
            }
            return (int)Math.Sqrt(number);
        }


        //The code below validates the user's input for login. If the inputs are incorrect, it returns various error messages using basic conditions.
        //Review the code to identify potential improvements.
        public void Exercise4()
        {
            string username = "user123";
            string password = "pass123";

            if (string.IsNullOrEmpty(username))
            {
                Console.WriteLine("Username cannot be empty.");
                return;
            }

            if (username.Length < 5)
            {
                Console.WriteLine("Username must be at least 5 characters long.");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

            if (password.Length < 6)
            {
                Console.WriteLine("Password must be at least 6 characters long.");
                return;
            }

            Console.WriteLine("User is valid.");
        }

        //The code below processes an order and uses multiple nested if statements to check for errors.
        //Review the code to identify potential improvements.
        public void Exercise6(Order order)
        {
            if (order != null)
            {
                if (order.Quantity > 0)
                {
                    if (order.Price > 0)
                    {
                        double total = order.Quantity * order.Price;
                        Console.WriteLine($"Order total: {total}");
                    }
                    else
                    {
                        Console.WriteLine("Price must be greater than zero.");
                    }
                }
                else
                {
                    Console.WriteLine("Quantity must be greater than zero.");
                }
            }
            else
            {
                Console.WriteLine("Order cannot be null.");
            }
        }

        public class Order
        {
            public int Quantity { get; set; }
            public double Price { get; set; }
        }

        //The code below calls several methods (FetchUser, GetAccountDetails, ProcessTransaction).
        //Each method returns an object or value that needs to be checked before proceeding to the next step.
        //Review the code to identify potential improvements in error handling.
        public void Exercise8()
        {
            User user = FetchUser("user123");
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Account account = GetAccountDetails(user);
            if (account == null)
            {
                Console.WriteLine("Account details could not be retrieved.");
                return;
            }

            bool transactionSuccessful = ProcessTransaction(account, 500);
            if (!transactionSuccessful)
            {
                Console.WriteLine("Transaction failed.");
                return;
            }

            Console.WriteLine("Transaction completed successfully.");
        }

        private User FetchUser(string username)
        {
            // Simulate fetching a user
            return username == "user123" ? new User() : null;
        }

        private Account GetAccountDetails(User user)
        {
            // Simulate getting account details
            return user != null ? new Account() : null;
        }

        private bool ProcessTransaction(Account account, double amount)
        {
            // Simulate processing a transaction
            return amount <= account.Balance;
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
