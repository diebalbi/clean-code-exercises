namespace Exercises
{
    internal class ControlStructurLevel
    {
        // This code uses a complex conditional that can be simplified. Review the structure and refactor it to make it more readable.
        public void Exercise1()
        {
            int number = 15;

            if (number > 0)
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine("The number is positive and even.");
                }
                else
                {
                    Console.WriteLine("The number is positive and odd.");
                }
            }
            else
            {
                Console.WriteLine("The number is not positive.");
            }
        }

        // This loop contains unnecessary logic and nested conditions. Refactor the code to make it simpler and more efficient.
        public void Exercise2()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    if (numbers[i] > 5)
                    {
                        Console.WriteLine(numbers[i] + " is even and greater than 5.");
                    }
                }
            }
        }

        // This code has a complex switch statement with redundant logic. Refactor it to make it clearer and reduce redundancy
        public void Exercise3()
        {
            int month = 2;
            string season;

            switch (month)
            {
                case 12:
                case 1:
                case 2:
                    season = "Winter";
                    break;
                case 3:
                case 4:
                case 5:
                    season = "Spring";
                    break;
                case 6:
                case 7:
                case 8:
                    season = "Summer";
                    break;
                case 9:
                case 10:
                case 11:
                    season = "Autumn";
                    break;
                default:
                    season = "Unknown";
                    break;
            }

            Console.WriteLine($"The season is: {season}");
        }

        // The code contains an overly complex for loop with a nested if condition. Simplify this code by breaking it down into smaller methods
        // and using clearer structures.
        public void Exercise4()
        {
            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i + " is even.");
                }
                else
                {
                    if (i % 3 == 0)
                    {
                        Console.WriteLine(i + " is odd and divisible by 3.");
                    }
                    else
                    {
                        Console.WriteLine(i + " is odd.");
                    }
                }
            }
        }

        //The code below contains six nested if statements. In each else block, a message is returned. Refactor this code to remove the deep nesting.
        public void Exercise5()
        {
            int age = 25;
            string message = CheckAgeGroup(age);
            Console.WriteLine(message);
        }

        private string CheckAgeGroup(int age)
        {
            if (age < 0)
            {
                return "Invalid age.";
            }
            else
            {
                if (age < 13)
                {
                    return "Child.";
                }
                else
                {
                    if (age < 18)
                    {
                        return "Teenager.";
                    }
                    else
                    {
                        if (age < 30)
                        {
                            return "Young Adult.";
                        }
                        else
                        {
                            if (age < 65)
                            {
                                return "Adult.";
                            }
                            else
                            {
                                return "Senior.";
                            }
                        }
                    }
                }
            }
        }

        // The following code checks multiple conditions before proceeding to the main logic.
        // Refactor it using guard clauses to handle the validations early and reduce nesting.
        public void Exercise6()
        {
            string username = "user123";
            string password = "pass";

            if (!string.IsNullOrEmpty(username))
            {
                if (!string.IsNullOrEmpty(password))
                {
                    if (password.Length >= 6)
                    {
                        Console.WriteLine("User login successful.");
                    }
                    else
                    {
                        Console.WriteLine("Password must be at least 6 characters long.");
                    }
                }
                else
                {
                    Console.WriteLine("Password cannot be empty.");
                }
            }
            else
            {
                Console.WriteLine("Username cannot be empty.");
            }
        }

        // This code checks for null values and then proceeds with calculations. Simplify it using guard clauses.
        public void Exercise7(Product product)
        {
            if (product != null)
            {
                if (product.Price != null)
                {
                    if (product.Quantity > 0)
                    {
                        decimal total = product.Price.Value * product.Quantity;
                        Console.WriteLine("Total: " + total);
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity.");
                    }
                }
                else
                {
                    Console.WriteLine("Price is not set.");
                }
            }
            else
            {
                Console.WriteLine("Product is null.");
            }
        }

        public class Product
        {
            public decimal? Price { get; set; }
            public int Quantity { get; set; }
        }

        // The following code has a complex set of conditions and calculations inside the main method.
        // Extract the calculations into a separate method to simplify the main logic.
        public void Exercise8()
        {
            int a = 10;
            int b = 5;
            int c = 2;

            if (a > b)
            {
                int result = a + b * c;
                Console.WriteLine("Result: " + result);
            }
            else
            {
                int result = a - b / c;
                Console.WriteLine("Result: " + result);
            }
        }

        // This code contains repetitive logic for validating user inputs. Extract this validation logic into a separate method.
        public void Exercise9()
        {
            string username = "user123";
            string password = "pass123";

            if (!string.IsNullOrEmpty(username) && username.Length >= 5)
            {
                if (!string.IsNullOrEmpty(password) && password.Length >= 6)
                {
                    Console.WriteLine("User is valid.");
                }
                else
                {
                    Console.WriteLine("Password is invalid.");
                }
            }
            else
            {
                Console.WriteLine("Username is invalid.");
            }
        }

        //The code contains magic numbers, and comments have been added to explain what each value represents.
        //Improve the code.
        public void Exercise10()
        {
            int quantity = 5;
            int pricePerItem = 20; // Price of each item in dollars

            // Apply a discount if the quantity is greater than 10
            if (quantity > 10)
            {
                int totalCost = quantity * pricePerItem - 100; // 100 is the discount amount
                Console.WriteLine("Total cost with discount: " + totalCost);
            }
            else
            {
                int totalCost = quantity * pricePerItem;
                Console.WriteLine("Total cost: " + totalCost);
            }
        }

        //The code uses magic strings for comparison, and comments explain what each string represents.
        //Improve the code
        public void Exercise11()
        {
            string userType = "admin"; // User type: admin, guest, or user

            if (userType == "admin") // Check if the user is an admin
            {
                Console.WriteLine("Welcome, Admin!");
            }
            else if (userType == "guest") // Check if the user is a guest
            {
                Console.WriteLine("Welcome, Guest!");
            }
            else
            {
                Console.WriteLine("Welcome, User!"); // Default message for regular users
            }
        }

        // The code includes magic numbers used for various grade thresholds, with comments explaining each one.
        // Improve the code.
        public void Exercise12()
        {
            int score = 75;

            // 90 represents the minimum score for an 'A' grade
            if (score >= 90)
            {
                Console.WriteLine("Grade: A");
            }
            // 80 represents the minimum score for a 'B' grade
            else if (score >= 80)
            {
                Console.WriteLine("Grade: B");
            }
            // 70 represents the minimum score for a 'C' grade
            else if (score >= 70)
            {
                Console.WriteLine("Grade: C");
            }
            // 60 represents the minimum score for a 'D' grade
            else if (score >= 60)
            {
                Console.WriteLine("Grade: D");
            }
            else
            {
                Console.WriteLine("Grade: F");
            }
        }

        // The following code contains a complex nested conditional structure using negative checks and magic numbers.
        // Refactor the code to use positive statements, meaningful names, and constants.
        public void Exercise14()
        {
            int userAge = 17;
            bool hasNoPermission = true;

            if (!(userAge >= 18) && hasNoPermission)
            {
                Console.WriteLine("Access denied.");
            }
            else if (!(userAge >= 18) && !hasNoPermission)
            {
                Console.WriteLine("Requires parental permission.");
            }
            else if (userAge >= 18)
            {
                Console.WriteLine("Access granted.");
            }
        }

        //

    }
}
