namespace Solutions.Integrative_Solutions
{
    //- Separation of Responsibilities: Created three new classes (PaymentProcessor, CustomerRepository, OrderConfirmationSender)
    // to handle payment processing, customer information updates, and order confirmations, respectively.
    //- Dependency Injection: Used constructor injection to pass dependencies(PaymentProcessor, CustomerRepository, and OrderConfirmationSender)
    // into the CustomerManager class, promoting modularity.
    //- Simplified Logic: Moved payment logic to PaymentProcessor, updating customer information to CustomerRepository, and confirmation
    // sending to OrderConfirmationSender

    public class Solution2
    {
        public class CustomerManager
        {
            private readonly PaymentProcessor _paymentProcessor;
            private readonly CustomerRepository _customerRepository;
            private readonly OrderConfirmationSender _orderConfirmationSender;

            public CustomerManager(PaymentProcessor paymentProcessor, CustomerRepository customerRepository, OrderConfirmationSender orderConfirmationSender)
            {
                _paymentProcessor = paymentProcessor;
                _customerRepository = customerRepository;
                _orderConfirmationSender = orderConfirmationSender;
            }

            public void ProcessOrder(string customerName, double orderAmount, string paymentMethod)
            {
                ValidateOrder(customerName, orderAmount);

                _paymentProcessor.ProcessPayment(orderAmount, paymentMethod);

                _customerRepository.UpdateCustomerInformation(customerName);
                _orderConfirmationSender.SendConfirmation(customerName);

                Console.WriteLine($"Order processed for customer: {customerName}");
            }

            private static void ValidateOrder(string customerName, double orderAmount)
            {
                if (string.IsNullOrEmpty(customerName) || orderAmount <= 0)
                {
                    throw new Exception("Invalid order details.");
                }
            }
        }

        public class PaymentProcessor
        {
            public void ProcessPayment(double amount, string method)
            {
                ValidatePaymentMethod(method);

                switch (method)
                {
                    case "CreditCard":
                        Console.WriteLine("Processing credit card payment...");
                        break;
                    case "PayPal":
                        Console.WriteLine("Processing PayPal payment...");
                        break;
                    default:
                        throw new Exception("Unknown payment method.");
                }
            }

            private static void ValidatePaymentMethod(string method)
            {
                if (string.IsNullOrEmpty(method))
                {
                    throw new Exception("Invalid payment method.");
                }
            }
        }

        public class CustomerRepository
        {
            public void UpdateCustomerInformation(string customerName)
            {
                Console.WriteLine($"Updating information for customer: {customerName}");
            }
        }

        public class OrderConfirmationSender
        {
            public void SendConfirmation(string customerName)
            {
                Console.WriteLine($"Order confirmation sent to customer: {customerName}");
            }
        }
    }
}
