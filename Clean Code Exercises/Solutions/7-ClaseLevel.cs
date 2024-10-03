namespace Solutions
{
    internal class ClaseLevel
    {
        // Improvement:
        //- Separation of Responsibilities: Split the Order class into three separate classes: Order for data storage,
        // PaymentProcessor for payment processing, and TransactionLogger for logging transactions.
        //- Cohesion: Each class now has a single responsibility, making the code easier to understand and maintain.
        public void Exercise1()
        {
            Order order = new Order { ProductName = "Laptop", Quantity = 2, Price = 1500.0 };
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            paymentProcessor.ProcessPayment(order);
        }

        public class Order
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
        }

        public class PaymentProcessor
        {
            public void ProcessPayment(Order order)
            {
                if (order.Quantity <= 0 || order.Price <= 0)
                {
                    throw new Exception("Invalid quantity or price.");
                }

                double total = order.Quantity * order.Price;
                Console.WriteLine($"Payment of {total} processed for {order.ProductName}.");

                TransactionLogger.LogTransaction(order.ProductName, total);
            }
        }

        public static class TransactionLogger
        {
            public static void LogTransaction(string productName, double amount)
            {
                Console.WriteLine($"Transaction logged: Product = {productName}, Amount = {amount}");
            }
        }

        // Improvement:
        //- Reduce Coupling: Introduced constructor injection in OrderService to inject dependencies (PaymentProcessor2 and TransactionLogger2),
        //reducing direct coupling between classes.
        //- Separation of Responsibilities: Each class (Order2, PaymentProcessor2, TransactionLogger2) now focuses on a specific responsibility,
        //making the design more flexible and maintainable.

        public void Exercise2()
        {
            PaymentProcessor2 paymentProcessor = new PaymentProcessor2();
            TransactionLogger2 transactionLogger = new TransactionLogger2();
            OrderService orderService = new OrderService(paymentProcessor, transactionLogger);
            orderService.CreateOrder("Laptop", 2, 1500.0);
        }

        public class OrderService
        {
            private readonly PaymentProcessor2 _paymentProcessor;
            private readonly TransactionLogger2 _transactionLogger;

            public OrderService(PaymentProcessor2 paymentProcessor, TransactionLogger2 transactionLogger)
            {
                _paymentProcessor = paymentProcessor;
                _transactionLogger = transactionLogger;
            }

            public void CreateOrder(string productName, int quantity, double price)
            {
                Order2 order = new Order2 { ProductName = productName, Quantity = quantity, Price = price };
                _paymentProcessor.ProcessPayment(order);
                _transactionLogger.LogTransaction(order);
            }
        }

        public class Order2
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
        }

        public class PaymentProcessor2
        {
            public void ProcessPayment(Order2 order)
            {
                Console.WriteLine($"Processing payment for {order.ProductName}, Quantity: {order.Quantity}, Total: {order.Quantity * order.Price}");
            }
        }

        public class TransactionLogger2
        {
            public void LogTransaction(Order2 order)
            {
                Console.WriteLine($"Transaction logged: {order.ProductName}, Quantity: {order.Quantity}, Price: {order.Price}");
            }
        }

        // Improvement:
        //- Separation of Responsibilities: The Warehouse class now delegates product management to InventoryManager and order processing
        // to OrderProcessor, ensuring that each class has a clear responsibility.
        //- Decoupling: The Product and Order classes are part of the domain and do not depend on higher-level management classes like
        // InventoryManager and OrderProcessor.
        //- Cohesion: Each class (Warehouse, InventoryManager, OrderProcessor, TransactionLogger3) now has a single, focused responsibility,
        // improving the modularity and maintainability of the design.


        public void Exercise3()
        {
            InventoryManager inventoryManager = new InventoryManager();
            TransactionLogger3 transactionLogger = new TransactionLogger3();
            OrderProcessor orderProcessor = new OrderProcessor(inventoryManager, transactionLogger);
            Warehouse warehouse = new Warehouse(inventoryManager, orderProcessor);

            warehouse.AddProduct("Laptop", 10, 1500.0);
            warehouse.ProcessOrder("Laptop", 2);
        }

        public class Warehouse
        {
            private readonly InventoryManager _inventoryManager;
            private readonly OrderProcessor _orderProcessor;

            public Warehouse(InventoryManager inventoryManager, OrderProcessor orderProcessor)
            {
                _inventoryManager = inventoryManager;
                _orderProcessor = orderProcessor;
            }

            public void AddProduct(string name, int quantity, double price)
            {
                _inventoryManager.AddProduct(new Product { Name = name, Quantity = quantity, Price = price });
            }

            public void ProcessOrder(string productName, int quantity)
            {
                _orderProcessor.ProcessOrder(productName, quantity);
            }
        }

        public class InventoryManager
        {
            private List<Product> _products = new List<Product>();

            public void AddProduct(Product product)
            {
                _products.Add(product);
                Console.WriteLine($"Product {product.Name} added to inventory.");
            }

            public Product GetProduct(string productName, int quantity)
            {
                Product product = _products.FirstOrDefault(p => p.Name == productName);
                if (product == null || product.Quantity < quantity)
                {
                    throw new Exception("Product not available or insufficient quantity.");
                }

                return product;
            }

            public void UpdateProductQuantity(Product product, int quantity)
            {
                product.Quantity -= quantity;
            }
        }

        public class OrderProcessor
        {
            private readonly InventoryManager _inventoryManager;
            private readonly TransactionLogger3 _transactionLogger;
            private List<Order3> _orders = new List<Order3>();

            public OrderProcessor(InventoryManager inventoryManager, TransactionLogger3 transactionLogger)
            {
                _inventoryManager = inventoryManager;
                _transactionLogger = transactionLogger;
            }

            public void ProcessOrder(string productName, int quantity)
            {
                Product product = _inventoryManager.GetProduct(productName, quantity);
                if (product == null) return;

                double totalCost = product.Price * quantity;
                _inventoryManager.UpdateProductQuantity(product, quantity);

                Order3 order = new Order3 { ProductName = productName, Quantity = quantity, TotalCost = totalCost };
                _orders.Add(order);

                _transactionLogger.LogTransaction(order);
            }
        }

        public class TransactionLogger3
        {
            public void LogTransaction(Order3 order)
            {
                Console.WriteLine($"Transaction logged: Product = {order.ProductName}, Quantity = {order.Quantity}, Total: {order.TotalCost}");
            }
        }

        public class Product
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
        }

        public class Order3
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public double TotalCost { get; set; }
        }

        // Improvement: 
        //- Delegating Domain Logic: The refactored solution moves the logic related to tasks and projects (AssignTask, CompleteTask) to
        // their respective classes (Project, Task), allowing them to manage their own behaviors.
        //- Encapsulation: Methods like MarkAsCompleted in Task and AddHoursWorked in Employee now encapsulate their respective logics,
        // avoiding direct manipulation from the ProjectManager class.
        //- Single Responsibility: The ProjectManager class now acts mainly as a coordinator, delegating domain-specific behaviors to
        // the appropriate classes.This improves cohesion and reduces the complexity of ProjectManager.
        public void Exercise4()
        {
            ProjectManager projectManager = new ProjectManager();
            projectManager.Employees.Add(new Employee { Name = "Alice" });
            projectManager.AddProject("Project A");
            projectManager.AssignTaskToEmployee("Project A", "Design Phase", "Alice");
            projectManager.CompleteTask("Project A", "Design Phase");
            projectManager.TrackEmployeeHours("Alice", 5);
        }

        public class ProjectManager
        {
            public List<Project> Projects { get; set; } = new List<Project>();
            public List<Employee> Employees { get; set; } = new List<Employee>();

            public void AddProject(string projectName)
            {
                Project project = new Project { Name = projectName, Tasks = new List<Task>() };
                Projects.Add(project);
                Console.WriteLine($"Project '{projectName}' added.");
            }

            public void AssignTaskToEmployee(string projectName, string taskName, string employeeName)
            {
                Project project = Projects.FirstOrDefault(p => p.Name == projectName);
                Employee employee = Employees.FirstOrDefault(e => e.Name == employeeName);

                if (project == null || employee == null)
                {
                    Console.WriteLine("Project or employee not found.");
                    return;
                }

                project.AssignTask(taskName, employee);
            }

            public void CompleteTask(string projectName, string taskName)
            {
                Project project = Projects.FirstOrDefault(p => p.Name == projectName);

                if (project == null)
                {
                    Console.WriteLine("Project not found.");
                    return;
                }

                project.CompleteTask(taskName);
            }

            public void TrackEmployeeHours(string employeeName, int hours)
            {
                Employee employee = Employees.FirstOrDefault(e => e.Name == employeeName);

                if (employee == null)
                {
                    Console.WriteLine("Employee not found.");
                    return;
                }

                employee.AddHoursWorked(hours);
            }
        }

        public class Project
        {
            public string Name { get; set; }
            public List<Task> Tasks { get; set; }

            public void AssignTask(string taskName, Employee employee)
            {
                Task task = new Task { Name = taskName, Status = "Pending", AssignedEmployee = employee };
                Tasks.Add(task);
                Console.WriteLine($"Task '{taskName}' assigned to '{employee.Name}' in project '{Name}'.");
            }

            public void CompleteTask(string taskName)
            {
                Task task = Tasks.FirstOrDefault(t => t.Name == taskName);
                if (task == null)
                {
                    Console.WriteLine("Task not found.");
                    return;
                }

                task.MarkAsCompleted();
            }
        }

        public class Task
        {
            public string Name { get; set; }
            public string Status { get; set; }
            public Employee AssignedEmployee { get; set; }

            public void MarkAsCompleted()
            {
                Status = "Completed";
                Console.WriteLine($"Task '{Name}' marked as completed.");
            }
        }

        public class Employee
        {
            public string Name { get; set; }
            public int TotalHoursWorked { get; private set; }

            public void AddHoursWorked(int hours)
            {
                TotalHoursWorked += hours;
                Console.WriteLine($"Added {hours} hours to employee '{Name}'. Total hours: {TotalHoursWorked}");
            }
        }
    }
}
