namespace Exercises
{
    internal class FormatLevel
    {
        //The code below contains multiple issues with density and distance. Some blocks of code are not separated by line breaks,
        //making it difficult to read. Separate the concepts with proper line breaks to improve readability.
        public void Exercise1()
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Iteration: " + i);
                if (i % 2 == 0) { Console.WriteLine("Even number"); }
                else { Console.WriteLine("Odd number"); }
            }
            int sum = 0; for (int i = 0; i < count; i++) { sum += i; }
            Console.WriteLine("Total sum: " + sum);
        }

        //The code lacks spacing between methods and is not ordered by call hierarchy. Rearrange the methods based on the order of their calls and
        //add appropriate line breaks.
        public void Exercise2()
        {
            int number = 5;
            PrintResult(number);
        }
        private void PrintResult(int value)
        {
            bool isPositive = IsPositive(value);
            if (isPositive) { Console.WriteLine("The number is positive."); }
            else { Console.WriteLine("The number is not positive."); }
        }
        private bool IsPositive(int number) { return number > 0; }

        //This code has issues with density, distance, and order. Some concepts are mixed together, and methods are scattered.
        //Organize the code, separate different sections, and arrange methods in the order of their calls
        public void Exercise3()
        {
            double price = 100;
            double discount = 0.2;
            double finalPrice = CalculateFinalPrice(price, discount);
            PrintPrice(finalPrice);
        }
        private void PrintPrice(double price) { Console.WriteLine("The final price is: " + price); }
        private double CalculateFinalPrice(double price, double discount) { return price - (price * discount); }
        private void LogCalculation(double price, double discount, double finalPrice) { Console.WriteLine($"Price: {price}, Discount: {discount}, Final Price: {finalPrice}"); }

        //The code contains a mix of related and unrelated concepts. Improve the code by separating different sections with line breaks
        //and arranging methods in a logical call order.
        public void Exercise4()
        {
            int result = AddNumbers(5, 3);
            DisplayResult(result);
        }
        private int AddNumbers(int a, int b) { return a + b; }
        private void DisplayResult(int result) { Console.WriteLine("Result: " + result); }
        private bool IsPositive2(int number) { return number > 0; } //Ignore the name of this method
        private void PrintPositiveOrNegative(int number) { if (IsPositive2(number)) { Console.WriteLine("Positive"); } else { Console.WriteLine("Negative"); } }

        //The code below defines a class that contains various elements (constants, private variables, properties, methods, constructor) arranged
        //in a disorganized manner. Your task is to reorder the elements in a way that follows the best practices of code organization.
        //Be mindful of where to place methods, properties, and the constructor.
        public void Exercise5()
        {
            Calculator calculator = new Calculator();
            int sum = calculator.AddNumbers(5, 3);
            calculator.PrintResult(sum);
        }

        public class Calculator
        {
            private int numberA;
            private int numberB;

            public int Result { get; private set; }

            public int AddNumbers(int a, int b)
            {
                numberA = a;
                numberB = b;
                int result = PerformAddition();
                LogResult(result);
                return result;
            }

            public Calculator()
            {
                numberA = 0;
                numberB = 0;
            }


            public void PrintResult(int result)
            {
                LogResult(result);
                Console.WriteLine("Result: " + result);
            }

            private int PerformAddition()
            {
                return numberA + numberB;
            }

            public static void DisplayMessage()
            {
                Console.WriteLine("Welcome to the Calculator!");
            }

            private void LogResult(int result)
            {
                Console.WriteLine("Logging result: " + result);
            }

            private const int MaxValue = 1000;
            public static void PrintMaxValue()
            {
                Console.WriteLine("Max Value: " + MaxValue);
            }
        }

    }
}
