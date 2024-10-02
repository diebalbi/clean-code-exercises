namespace Exercises
{
    public class NamesLevel
    {

        // The following code prints numbers from 0 to 9. Some variable names are not clear and can be improved.
        public void Exercise1()
        {
            int n = 0;
            while (n < 10)
            {
                Console.WriteLine(n);
                n++;
            }
        }


        //This code performs the addition of two numbers and displays the result on the screen.
        public void Exercise2()
        {
            int x = 5;
            int y = 3;
            int z = Add(x, y);
            Console.WriteLine(z);
        }

        private static int Add(int a, int b)
        {
            return a + b;
        }

        //This code calculates the total amount with an applied tax. The names used are confusing and could be improved.
        public void Exercise3()
        {
            int t = CalculateTotal(100, 0.2);
            Console.WriteLine(t);
        }

        private int CalculateTotal(int a, double r)
        {
            return a + (int)(a * r);
        }

        //This code applies a discount to a price and shows the final price. There are some unclear variable names that could be made more meaningful.
        public void Exercise4()
        {
            double num = 150;
            double discount = 0.1;
            double res = GetDisc(num, discount);
            Console.WriteLine(res);
        }

        private double GetDisc(double p, double d)
        {
            return p - (p * d);
        }


        //This code sums up the elements of a list. Some names could be made clearer, and the code could be simplified for better readability.
        public void Exercise5()
        {
            List<int> arr = new List<int> { 1, 2, 3, 4, 5 };
            int sum = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine("Sum: " + sum);
        }


        //This code defines a class that represents a person and displays their information. Some variable names are not meaningful and should be improved.
        public void Exercise6()
        {
            Person p = new Person("John", 30);
            p.d();
        }

        public class Person
        {
            public string n;
            public int a;

            public Person(string n, int a)
            {
                this.n = n;
                this.a = a;
            }

            public void d()
            {
                Console.WriteLine(n + " is " + a + " years old.");
            }
        }

    }
}
