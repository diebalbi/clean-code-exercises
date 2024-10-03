namespace Exercises
{
    internal class FunctionLevel
    {
        // The following code has a single, large function that performs multiple tasks.
        // Review the code and think about how it could be improved to enhance readability and maintainability.
        public void Exercise1()
        {
            string username = "user123";
            string password = "pass123";

            // Validate user credentials
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Username or password cannot be empty.");
                return;
            }

            if (username.Length < 5 || password.Length < 6)
            {
                Console.WriteLine("Invalid username or password length.");
                return;
            }

            // Authenticate user
            bool isAuthenticated = (username == "user123" && password == "pass123");

            if (!isAuthenticated)
            {
                Console.WriteLine("Authentication failed.");
                return;
            }

            // Perform some post-authentication actions
            Console.WriteLine("User authenticated successfully.");
            Console.WriteLine("Welcome, " + username + "!");
        }

        // The code below has a function that takes several parameters to perform a calculation.
        // Consider how you might improve the code to make it easier to use and extend in the future.
        public void Exercise2()
        {
            string productName = "Laptop";
            int quantity = 2;
            double price = 1500.0;

            double total = CalculateTotal(productName, quantity, price);
            Console.WriteLine("Total cost: " + total);
        }

        private double CalculateTotal(string productName, int quantity, double price)
        {
            if (quantity <= 0 || price <= 0)
            {
                Console.WriteLine("Invalid quantity or price.");
                return -1;
            }

            return quantity * price;
        }

        // The code below mixes high-level actions (retrieving user data) with low-level details (parsing and displaying user information)
        // within the same function. Review the code and think about how you could structure it to keep the levels of abstraction separate.
        public void Exercise3()
        {
            string userData = GetUserData();

            if (!string.IsNullOrEmpty(userData))
            {
                string[] userParts = userData.Split(',');

                string username = userParts[0].Trim();
                string email = userParts[1].Trim();

                Console.WriteLine($"Username: {username}");
                Console.WriteLine($"Email: {email}");
            }
            else
            {
                Console.WriteLine("No user data found.");
            }
        }

        private string GetUserData()
        {
            // Simulate fetching user data
            return "user123, user123@example.com";
        }

        //The following code processes an order, validates multiple conditions, and calculates the total cost.
        //It mixes validation, error handling, and business logic in the same method.
        //Review the code and consider how you might refactor it to improve readability and error handling.
        public void Exercise4()
        {
            string productName = "Laptop";
            int quantity = 3;
            double price = 1200.0;

            if (string.IsNullOrEmpty(productName))
            {
                Console.WriteLine("Product name cannot be empty.");
                return;
            }

            if (quantity <= 0 || price <= 0)
            {
                Console.WriteLine("Invalid quantity or price.");
                return;
            }

            double totalCost = quantity * price;

            if (totalCost > 5000)
            {
                Console.WriteLine("The total cost exceeds the limit.");
                return;
            }

            Console.WriteLine($"Order for {productName} processed. Total cost: {totalCost}");
        }



        // The following code retrieves user details, validates input, and performs actions based on various conditions.
        // The method is complex and has nested structures. Review the code and identify ways to simplify and improve it.
        public void Exercise5()
        {
            string userData = GetAdminData();

            if (!string.IsNullOrEmpty(userData))
            {
                string[] userParts = userData.Split(',');

                if (userParts.Length == 2)
                {
                    string username = userParts[0].Trim();
                    string email = userParts[1].Trim();

                    if (username.Length >= 5 && email.Contains("@"))
                    {
                        Console.WriteLine($"User: {username}, Email: {email}");

                        if (username == "admin")
                        {
                            Console.WriteLine("Admin access granted.");
                        }
                        else
                        {
                            Console.WriteLine("Regular user access.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or email format.");
                    }
                }
                else
                {
                    Console.WriteLine("User data is incomplete.");
                }
            }
            else
            {
                Console.WriteLine("No user data found.");
            }
        }

        private string GetAdminData()
        {
            // Simulate fetching admin data
            return "admin, admin@example.com";
        }

    }
}
