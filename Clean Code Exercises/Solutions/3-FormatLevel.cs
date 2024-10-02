namespace Solutions
{
    internal class FormatLevel
    {
        //Improvement: Added line breaks to separate different logical sections, such as between variable declarations, loops, and conditionals,
        //improving the density and distance of the code.
        public void Exercise1()
        {
            int count = 10;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Iteration: " + i);

                if (i % 2 == 0)
                {
                    Console.WriteLine("Even number");
                }
                else
                {
                    Console.WriteLine("Odd number");
                }
            }

            int sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += i;
            }

            Console.WriteLine("Total sum: " + sum);
        }

        //Improvement: Added line breaks to separate methods and placed them in the order they are called,
        //improving the overall structure and readability.
        public void Exercise2()
        {
            int number = 5;
            PrintResult(number);
        }

        private void PrintResult(int value)
        {
            bool isPositive = IsPositive(value);

            if (isPositive)
            {
                Console.WriteLine("The number is positive.");
            }
            else
            {
                Console.WriteLine("The number is not positive.");
            }
        }

        private bool IsPositive(int number)
        {
            return number > 0;
        }

        //Improvement:  Added line breaks to separate different blocks of code, grouped related code segments,
        //and reordered methods based on the sequence of their calls.
        public void Exercise3()
        {
            double price = 100;
            double discount = 0.2;
            double finalPrice = CalculateFinalPrice(price, discount);

            PrintPrice(finalPrice);
        }

        private double CalculateFinalPrice(double price, double discount)
        {
            return price - (price * discount);
        }

        private void PrintPrice(double price)
        {
            Console.WriteLine("The final price is: " + price);
        }

        private void LogCalculation(double price, double discount, double finalPrice)
        {
            Console.WriteLine($"Price: {price}, Discount: {discount}, Final Price: {finalPrice}");
        }


        //Improvement: Improved the vertical spacing by adding line breaks between methods and placing methods in the order they are used
        //or logically grouped, enhancing code clarity.
        public void Exercise4()
        {
            int result = AddNumbers(5, 3);
            DisplayResult(result);
        }

        private int AddNumbers(int a, int b)
        {
            return a + b;
        }

        private void DisplayResult(int result)
        {
            Console.WriteLine("Result: " + result);
        }

        private bool IsPositive2(int number)
        {
            return number > 0;
        }

        private void PrintPositiveOrNegative(int number)
        {
            if (IsPositive2(number))
            {
                Console.WriteLine("Positive");
            }
            else
            {
                Console.WriteLine("Negative");
            }
        }

        //Improvement: 
        // - Constants: Placed at the top of the class after the opening brace, as they are part of the class's static information.
        // - Private Variables: Positioned right after constants, as they represent internal state.
        // - Properties: Placed after the private variables to expose internal state in a controlled manner.
        // - Constructor: Added right after properties to initialize the class's internal state.
        // - Public Methods: Placed after the constructor.Directly after a public method(e.g., AddNumbers),
        // the private methods it calls(PerformAddition, LogResult) are placed, before moving on to the next public method.
        // - Private Methods: Positioned directly after the public methods that invoke them, making it easier to understand internal call relationships.
        // - Static Methods: Static methods used within the class (PrintMaxValue) are placed near the methods that call or use them.
        // Static methods not used internally(DisplayMessage) are placed at the end.
        public void Exercise5()
        {
            Calculator calculator = new Calculator();
            int sum = calculator.AddNumbers(5, 3);
            calculator.PrintResult(sum);
        }

        public class Calculator
        {
            private const int MaxValue = 1000;

            private int numberA;
            private int numberB;

            public int Result { get; private set; }

            public Calculator()
            {
                numberA = 0;
                numberB = 0;
            }

            public int AddNumbers(int a, int b)
            {
                numberA = a;
                numberB = b;
                int result = PerformAddition();
                LogResult(result);
                return result;
            }

            private int PerformAddition()
            {
                return numberA + numberB;
            }

            private void LogResult(int result)
            {
                Console.WriteLine("Logging result: " + result);
            }

            public void PrintResult(int result)
            {
                LogResult(result);
                Console.WriteLine("Result: " + result);
            }

            public static void PrintMaxValue()
            {
                Console.WriteLine("Max Value: " + MaxValue);
            }

            public static void DisplayMessage()
            {
                Console.WriteLine("Welcome to the Calculator!");
            }
        }
    }
}
