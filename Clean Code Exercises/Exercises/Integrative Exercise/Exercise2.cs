namespace Exercises.Integrative_Exercise
{
    // The CustomerManager class mixes several responsibilities, such as processing payments, updating customer information,
    // and sending confirmations, violating the Single Responsibility Principle.

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
