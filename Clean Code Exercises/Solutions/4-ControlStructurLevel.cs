namespace Solutions
{
    internal class ControlStructurLevel
    {
        //Improvement: Simplified the nested if statements by using an early return and a ternary operator to handle the parity of the number,
        //improving readability.
        public void Exercise1()
        {
            int number = 15;

            if (number <= 0)
            {
                Console.WriteLine("The number is not positive.");
                return;
            }

            string parity = (number % 2 == 0) ? "even" : "odd";
            Console.WriteLine($"The number is positive and {parity}.");
        }

        //Improvement: Combined the conditions into a single if statement and used a foreach loop for better readability and to avoid
        //accessing array elements with an index unnecessarily.
        public void Exercise2()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach (int number in numbers)
            {
                if (number % 2 == 0 && number > 5)
                {
                    Console.WriteLine($"{number} is even and greater than 5.");
                }
            }
        }


        //Improvement: Simplified the switch statement using a switch expression, which reduces the code and makes it more readable.
        public void Exercise3()
        {
            int month = 2;
            string season = month switch
            {
                12 or 1 or 2 => "Winter",
                3 or 4 or 5 => "Spring",
                6 or 7 or 8 => "Summer",
                9 or 10 or 11 => "Autumn",
                _ => "Unknown"
            };

            Console.WriteLine($"The season is: {season}");
        }

        //Improvement: Moved the logic to a separate method (PrintNumberInfo) and simplified the nested if statements.
        //This not only makes the code clearer but also follows the principle of separating concerns.
        public void Exercise4()
        {
            for (int i = 0; i < 20; i++)
            {
                PrintNumberInfo(i);
            }
        }

        private void PrintNumberInfo(int number)
        {
            if (number % 2 == 0)
            {
                Console.WriteLine($"{number} is even.");
                return;
            }

            if (number % 3 == 0)
            {
                Console.WriteLine($"{number} is odd and divisible by 3.");
                return;
            }

            Console.WriteLine($"{number} is odd.");
        }

        // When to Use Early Returns: Early returns are useful when you want to handle specific conditions right away and exit the method to avoid
        // unnecessary complexity.
        // They work best in scenarios where certain actions are mutually exclusive, like in this example, where we check if a number is even
        // or divisible by 3.
        // By handling each condition as soon as it's encountered, the method becomes easier to read and understand.
        // Early returns help in reducing nesting and make the code more linear, which enhances its clarity and maintainability.
        // Use early returns when you want to address edge cases or specific conditions upfront, allowing the main logic of the method to remain
        // straightforward.


        //Improvement: Refactor the code to use Guard Clauses and extract the logic into separate methods to improve readability and reduce complexity.
        public void Exercise5()
        {
            int age = 25;
            string message = GetAgeGroupMessage(age);
            Console.WriteLine(message);
        }

        private string GetAgeGroupMessage(int age)
        {
            if (age < 0) return "Invalid age.";
            if (age < 13) return "Child.";
            if (age < 18) return "Teenager.";
            if (age < 30) return "Young Adult.";
            if (age < 65) return "Adult.";

            return "Senior.";
        }

        // When to Use Guard Clauses: Guard clauses are an effective way to handle edge cases or specific conditions right at the start of a function,
        // allowing you to return or exit early.
        // This eliminates the need for deep nesting of if statements, making the code easier to read and maintain.
        // In this solution, each condition is checked sequentially, and the method returns immediately if the condition is met.
        // This approach simplifies the logic flow, reducing the overall complexity.

        //Improvement: The refactoring uses guard clauses to handle invalid input conditions immediately, which simplifies the control flow
        //and avoids deep nesting.
        public void Exercise6()
        {
            string username = "user123";
            string password = "pass";

            if (string.IsNullOrEmpty(username))
            {
                Console.WriteLine("Username cannot be empty.");
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

            Console.WriteLine("User login successful.");
        }


        //Improvement:  Guard clauses handle each invalid condition immediately, which avoids the need for nested if statements and makes
        //the code flow more straightforward
        public void Exercise7(Product product)
        {
            if (product == null)
            {
                Console.WriteLine("Product is null.");
                return;
            }

            if (product.Price == null)
            {
                Console.WriteLine("Price is not set.");
                return;
            }

            if (product.Quantity <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            decimal total = product.Price.Value * product.Quantity;
            Console.WriteLine("Total: " + total);
        }

        public class Product
        {
            public decimal? Price { get; set; }
            public int Quantity { get; set; }
        }


        //Improvement: Extracting the calculation logic into a new method (CalculateResult) simplifies the main method,
        //making it easier to read and understand
        public void Exercise8()
        {
            int firstNumber = 10;
            int secondNumber = 5;
            int multiplier = 2;

            int result = CalculateResult(firstNumber, secondNumber, multiplier);
            Console.WriteLine("Result: " + result);
        }

        private int CalculateResult(int firstNumber, int secondNumber, int multiplier)
        {
            if (firstNumber > secondNumber)
            {
                return firstNumber + secondNumber * multiplier;
            }

            return firstNumber - secondNumber / multiplier;
        }

        //Improvement: The validation logic for username and password is extracted into a new method (IsValidUser).
        //This reduces the complexity in the main method and makes the validation logic reusable.
        public void Exercise9()
        {
            string username = "user123";
            string password = "pass123";

            if (IsValidUser(username, password))
            {
                Console.WriteLine("User is valid.");
            }
        }

        private bool IsValidUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 5)
            {
                Console.WriteLine("Username is invalid.");
                return false;
            }

            if (string.IsNullOrEmpty(password) || password.Length < 6)
            {
                Console.WriteLine("Password is invalid.");
                return false;
            }

            return true;
        } // How else can this exercise be improved?

        //Improvement:Replaced the magic numbers with meaningful constants based on the comments provided in the original code.
        //The comments were removed as the constants now provide context.
        public void Exercise10()
        {
            const int DiscountThreshold = 10;
            const int DiscountAmount = 100;
            const int PricePerItem = 20;

            int quantity = 5;

            int totalCost = CalculateTotalCost(quantity, PricePerItem, DiscountThreshold, DiscountAmount);
            Console.WriteLine("Total cost: " + totalCost);
        }

        private int CalculateTotalCost(int quantity, int pricePerItem, int discountThreshold, int discountAmount)
        {
            if (quantity > discountThreshold)
            {
                return quantity * pricePerItem - discountAmount;
            }
            else
            {
                return quantity * pricePerItem;
            }
        }

        //Improvement: The magic strings were replaced with constants (AdminUserType and GuestUserType),
        //and the comments were removed as the constants now make the code self-explanatory.
        const string AdminUserType = "admin";
        const string GuestUserType = "guest"; // Another option is to create a Enum for user types

        public void Exercise11()
        {
            string userType = AdminUserType;

            Console.WriteLine(GetWelcomeMessage(userType));
        }

        private string GetWelcomeMessage(string userType)
        {
            if (userType == AdminUserType)
            {
                return "Welcome, Admin!";
            }
            else if (userType == GuestUserType)
            {
                return "Welcome, Guest!";
            }
            else
            {
                return "Welcome, User!";
            }
        }

        // Improvement: This refactoring not only eliminates magic numbers but also provides a more structured way to handle related constants using an enum.
        // - Enums: Introduced an enum called Grade to represent the different grade thresholds.
        // Each grade is associated with an integer value that represents its minimum score.
        // - Casting: Used(int)Grade.GradeA, etc., to compare the score with the respective enum values.
        public void Exercise12()
        {
            int score = 75;
            Console.WriteLine($"Grade: {GetGrade(score)}");
        }

        private Grade GetGrade(int score)
        {
            if (score >= (int)Grade.GradeA)
            {
                return Grade.GradeA;
            }
            else if (score >= (int)Grade.GradeB)
            {
                return Grade.GradeB;
            }
            else if (score >= (int)Grade.GradeC)
            {
                return Grade.GradeC;
            }
            else if (score >= (int)Grade.GradeD)
            {
                return Grade.GradeD;
            }
            else
            {
                return Grade.GradeF;
            }
        }

        private enum Grade
        {
            GradeA = 90,
            GradeB = 80,
            GradeC = 70,
            GradeD = 60,
            GradeF = 0
        }


        //Improvement:
        // - Positive Conditions: Changed !(userAge >= 18) to userAge >= AdultAge and renamed hasNoPermission to hasPermission.
        // - Early Return: Used an early return for the adult age check to simplify the control flow.
        // - Magic Numbers: Introduced AdultAge as a constant to replace the magic number 18
        public void Exercise14()
        {
            const int AdultAge = 18;
            int userAge = 17;
            bool hasPermission = false;

            if (userAge >= AdultAge)
            {
                Console.WriteLine("Access granted.");
                return;
            }

            if (hasPermission)
            {
                Console.WriteLine("Requires parental permission.");
            }
            else
            {
                Console.WriteLine("Access denied.");
            }
        }


        //Improvement:
        // - Positive Statements: Changed isNotLoggedIn to isLoggedIn and adjusted conditions accordingly.
        // - Magic Strings: Introduced AdminRole and ModeratorRole as constants to replace the magic strings.
        // - Code Extraction: Moved the role access logic into a separate method (GetAccessMessage) to simplify the main method.
        // - Early Return: Used an early return to handle the "not logged in" check, reducing nesting.
        const string AdminRole = "admin";
        const string ModeratorRole = "moderator";
        public void Exercise15()
        {
            string userRole = "guest";
            bool isLoggedIn = false;

            if (!isLoggedIn)
            {
                Console.WriteLine("User not logged in.");
                return;
            }

            Console.WriteLine(GetAccessMessage(userRole));
        }

        private string GetAccessMessage(string userRole)
        {
            if (userRole == AdminRole || userRole == ModeratorRole)
            {
                return "User has full access.";
            }

            return "User has limited access.";
        }

    }
}
