namespace Solutions
{
    public class NameLevel
    {
        // Improvement: The variable counter is now more meaningful compared to the previous name.
        public void Exercise1()
        {
            int counter = 0;
            while (counter < 10)
            {
                Console.WriteLine(counter);
                counter++;
            }
        }


        // Improvement: Names have been updated to be more descriptive, clearly indicating the purpose of each variable
        public void Exercise2()
        {
            int firstNumber = 5;
            int secondNumber = 3;
            int sum = AddNumbers(firstNumber, secondNumber);
            Console.WriteLine(sum);
        }

        private int AddNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

        //Improvement: Variable and method names now indicate their purpose more clearly.
        public void Exercise3()
        {
            int totalAmount = CalculateTotalWithTax(100, 0.2);
            Console.WriteLine(totalAmount);
        }

        private int CalculateTotalWithTax(int baseAmount, double taxRate)
        {
            return baseAmount + (int)(baseAmount * taxRate);
        }

        //Improvement: The names now reflect the actual operations and values they represent
        public void Exercise4()
        {
            double originalPrice = 150;
            double discountRate = 0.1;
            double finalPrice = ApplyDiscount(originalPrice, discountRate);
            Console.WriteLine(finalPrice);
        }

        private double ApplyDiscount(double price, double discountRate)
        {
            return price - (price * discountRate);
        }

        //Improvement: Improved the naming of the list and utilized a foreach loop for better readability.
        public void Exercise5()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine("Sum: " + sum);
        }


        // Improvement: Names have been revised to clearly express their purpose, enhancing the overall readability of the code.
        public void Exercise6()
        {
            Person person = new Person("John", 30);
            person.ShowInfo();
        }

        public class Person
        {
            public string Name;
            public int Age;

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public void ShowInfo()
            {
                Console.WriteLine(Name + " is " + Age + " years old.");
            }
        }

    }
}
