namespace Exercises.Integrative_Exercise
{
    // The Count method processes a list of numbers to sum only those that end in an odd digit and then calculates the average.
    // However, the code has multiple Clean Code violations, including unclear naming, poor error handling, and an overly complex structure.

    public class Exercise2
    {
        public class CustomerManager
        {
            public void ProcessOrder(string customerName, double orderAmount, string paymentMethod)
            {
                if (string.IsNullOrEmpty(customerName) || orderAmount <= 0 || string.IsNullOrEmpty(paymentMethod))
                {
                    Console.WriteLine("Invalid order details.");
                    return;
                }

                Console.WriteLine($"Processing order for customer: {customerName}");
                Console.WriteLine($"Order amount: {orderAmount}");

                if (paymentMethod == "CreditCard")
                {
                    Console.WriteLine("Processing credit card payment...");
                }
                else if (paymentMethod == "PayPal")
                {
                    Console.WriteLine("Processing PayPal payment...");
                }
                else
                {
                    Console.WriteLine("Unknown payment method.");
                }

                // Update customer information
                Console.WriteLine("Updating customer information...");

                // Send confirmation
                Console.WriteLine("Order confirmation sent to customer.");
            }
        }
    }
}
