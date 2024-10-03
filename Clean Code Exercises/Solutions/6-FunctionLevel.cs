namespace Solutions
{
    internal class FunctionLevel
    {
        // Improvement:
        //- Single Responsibility: Broke down the large function into smaller functions(ValidateCredentials, ValidateAuthentication, PostAuthentication),
        // each handling a specific task.
        //- Abstraction: Each function abstracts away the details of a particular step, improving readability.
        public void Exercise1()
        {
            string username = "user123";
            string password = "pass123";

            ValidateCredentials(username, password);

            ValidateAuthentication(username, password);

            PostAuthentication(username);
        }

        private static void ValidateCredentials(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Username or password cannot be empty.");
            }

            if (username.Length < 5 || password.Length < 6)
            {
                throw new Exception("Invalid username or password length.");
            }
        }

        private static void ValidateAuthentication(string username, string password)
        {
            if (username != "user123" && password != "pass123")
            {
                throw new Exception("Authentication failed.");
            }
        }

        private static void PostAuthentication(string username)
        {
            Console.WriteLine("User authenticated successfully.");
            Console.WriteLine("Welcome, " + username + "!");
        }

        // Improvement:
        //- Reduced Parameters: Encapsulated the product data into a Product object, reducing the number of parameters in the CalculateTotal method.
        //- Clarity: Using an object makes the code more extensible and provides a clearer structure for related data.
        public void Exercise2()
        {
            Product product = new Product("Laptop", 2, 1500.0);

            double total = CalculateTotal(product);
            Console.WriteLine("Total cost: " + total);
        }

        private double CalculateTotal(Product product)
        {
            if (product.Quantity <= 0 || product.Price <= 0)
            {
                throw new Exception("Invalid quantity or price.");
            }

            return product.Quantity * product.Price;
        }

        public class Product
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }

            public Product(string name, int quantity, double price)
            {
                Name = name;
                Quantity = quantity;
                Price = price;
            }
        }

        // Improvement: 
        //-  Separation of Abstraction Levels: Extracted the parsing (ParseUserData) and displaying (DisplayUserInfo) logic
        // into separate methods to keep the main method (Exercise3) at a higher level of abstraction.
        //- Single Responsibility: Each function now has a single, clear responsibility, improving readability and maintainability.

        public void Exercise3()
        {
            string userData = GetUserData();
            ValidateUserData(userData);

            User user = ParseUserData(userData);
            DisplayUserInfo(user);
        }

        private string GetUserData()
        {
            // Simulate fetching user data
            return "user123, user123@example.com";
        }

        private static void ValidateUserData(string userData)
        {
            if (string.IsNullOrEmpty(userData))
            {
                throw new Exception("No user data found.");
            }
        }

        private User ParseUserData(string userData)
        {
            string[] userParts = userData.Split(',');

            string username = userParts[0].Trim();
            string email = userParts[1].Trim();

            return new User(username, email);
        }

        private void DisplayUserInfo(User user)
        {
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Email: {user.Email}");
        }

        public class User
        {
            public string Username { get; }
            public string Email { get; }

            public User(string username, string email)
            {
                Username = username;
                Email = email;
            }
        }

        // Improvement:
        //- Code Extraction: Separated validation (ValidateProduct, ValidateLimit) and calculation (CalculateTotalCost) into their own methods
        // to reduce the size of the main method and isolate responsibilities.
        //- Object Usage: Introduced a Product class to encapsulate product-related data, reducing the number of parameters passed to functions.
        //- Constants: Added a constant(OrderLimit) to replace the magic number 5000.
        //- Exception Handling: Used ArgumentException to handle errors in the validation method, which simplifies error management in the main method.

        private const double OrderLimit = 5000.0;
        public void Exercise4()
        {
            try
            {
                Product product = new Product("Laptop", 3, 1200.0);
                ValidateProduct(product);
                double totalCost = CalculateTotalCost(product);
                ValidateLimit(totalCost);

                Console.WriteLine($"Order for {product.Name} processed. Total cost: {totalCost}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ValidateProduct(Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
            {
                throw new ArgumentException("Product name cannot be empty.");
            }

            if (product.Quantity <= 0 || product.Price <= 0)
            {
                throw new ArgumentException("Invalid quantity or price.");
            }
        }

        private static double CalculateTotalCost(Product product)
        {
            return product.Quantity * product.Price;
        }

        private static void ValidateLimit(double totalCost)
        {
            if (totalCost > OrderLimit)
            {
                Console.WriteLine("The total cost exceeds the limit.");
                return;
            }
        }

        // Improvement:
        //- Code Extraction: Extracted different responsibilities into separate methods to keep each method focused on a single task.
        //- Object Usage: Created a User class to encapsulate user-related data, which simplifies parameter passing and improves code structure.
        //- Exception Handling: Used ArgumentException in ParseAdminData and ValidateAdmin to handle errors, allowing the main method
        // to remain clean and focused on the primary flow of actions.
        //- Guard Clauses: Used guard clauses in ParseAdminData and ValidateAdmin to handle errors immediately, which reduces nesting and improves
        // readability.
        public void Exercise5()
        {
            try
            {
                User user = ParseAdminData(GetAdminData());
                ValidateAdmin(user);
                DisplayAdminInfo(user);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static string GetAdminData()
        {
            // Simulate fetching user data
            return "admin, admin@example.com";
        }

        private static User ParseAdminData(string userData)
        {
            if (string.IsNullOrEmpty(userData))
            {
                throw new ArgumentException("No user data found.");
            }

            string[] userParts = userData.Split(',');

            if (userParts.Length != 2)
            {
                throw new ArgumentException("User data is incomplete.");
            }

            string username = userParts[0].Trim();
            string email = userParts[1].Trim();

            return new User(username, email);
        }

        private static void ValidateAdmin(User user)
        {
            if (user.Username.Length < 5 || !user.Email.Contains("@"))
            {
                throw new ArgumentException("Invalid username or email format.");
            }
        }

        private void DisplayAdminInfo(User user)
        {
            Console.WriteLine($"User: {user.Username}, Email: {user.Email}");

            if (user.Username == "admin")
            {
                Console.WriteLine("Admin access granted.");
            }
            else
            {
                Console.WriteLine("Regular user access.");
            }
        }
    }
}
