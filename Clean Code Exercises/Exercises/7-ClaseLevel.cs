namespace Exercises
{
    internal class ClaseLevel
    {
        // The Order class in the code below manages order details, processes payments, and logs transactions.
        // Analyze the class and consider how its current design might affect flexibility and readability
        public void Exercise1()
        {
            Order order = new Order { ProductName = "Laptop", Quantity = 2, Price = 1500.0 };
            order.ProcessPayment();
        }

        public class Order
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }

            public void ProcessPayment()
            {
                if (Quantity <= 0 || Price <= 0)
                {
                    Console.WriteLine("Invalid quantity or price.");
                    return;
                }

                double total = Quantity * Price;
                Console.WriteLine($"Payment of {total} processed for {ProductName}.");

                LogTransaction(ProductName, total);
            }

            private void LogTransaction(string productName, double amount)
            {
                Console.WriteLine($"Transaction logged: Product = {productName}, Amount = {amount}");
            }
        }

        //The OrderService class in the code below manages orders and interacts directly with other components.
        //This direct interaction might impact the flexibility of the class.
        //Analyze the code and think about how you might change its design to make it more modular and maintainable.
        public void Exercise2()
        {
            OrderService orderService = new OrderService();
            orderService.CreateOrder("Laptop", 2, 1500.0);
        }

        public class OrderService
        {
            public void CreateOrder(string productName, int quantity, double price)
            {
                Order2 order = new Order2 { ProductName = productName, Quantity = quantity, Price = price };
                PaymentProcessor2 paymentProcessor = new PaymentProcessor2();
                paymentProcessor.ProcessPayment(order);
                LogTransaction(order);
            }

            private void LogTransaction(Order2 order)
            {
                Console.WriteLine($"Transaction logged: {order.ProductName}, Quantity: {order.Quantity}, Price: {order.Price}");
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

        //The Warehouse class below is managing multiple responsibilities related to products, orders, and logging transactions.
        //Examine how these responsibilities could be better distributed across different classes without directly coupling
        //the domain classes (Product, Order) with higher-level management classes.
        public void Exercise3()
        {
            Warehouse warehouse = new Warehouse();
            warehouse.AddProduct("Laptop", 10, 1500.0);
            warehouse.ProcessOrder("Laptop", 2);
        }

        public class Warehouse
        {
            public List<Product> Products { get; set; } = new List<Product>();
            public List<Order3> Orders { get; set; } = new List<Order3>();

            public void AddProduct(string name, int quantity, double price)
            {
                Product product = new Product { Name = name, Quantity = quantity, Price = price };
                Products.Add(product);
                Console.WriteLine($"Product {name} added to the warehouse.");
            }

            public void ProcessOrder(string productName, int quantity)
            {
                Product product = Products.FirstOrDefault(p => p.Name == productName);
                if (product == null || product.Quantity < quantity)
                {
                    Console.WriteLine("Product not available or insufficient quantity.");
                    return;
                }

                double totalCost = product.Price * quantity;
                product.Quantity -= quantity;

                Order3 order = new Order3 { ProductName = productName, Quantity = quantity, TotalCost = totalCost };
                Orders.Add(order);

                LogTransaction(productName, quantity, totalCost);
            }

            private void LogTransaction(string productName, int quantity, double amount)
            {
                Console.WriteLine($"Transaction logged: Product = {productName}, Quantity = {quantity}, Amount = {amount}");
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

        // The ProjectManager class below manages multiple responsibilities for different domain objects (Task, Employee, Project).
        // It contains methods that directly manipulate the state and behavior of these domain objects.
        // Review the code to identify which parts of the logic could be moved to the classes that they pertain to.
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
                if (project == null)
                {
                    Console.WriteLine("Project not found.");
                    return;
                }

                Employee employee = Employees.FirstOrDefault(e => e.Name == employeeName);
                if (employee == null)
                {
                    Console.WriteLine("Employee not found.");
                    return;
                }

                Task task = new Task { Name = taskName, Status = "Pending", AssignedEmployee = employee };
                project.Tasks.Add(task);
                Console.WriteLine($"Task '{taskName}' assigned to '{employeeName}' in project '{projectName}'.");
            }

            public void CompleteTask(string projectName, string taskName)
            {
                Project project = Projects.FirstOrDefault(p => p.Name == projectName);
                if (project == null)
                {
                    Console.WriteLine("Project not found.");
                    return;
                }

                Task task = project.Tasks.FirstOrDefault(t => t.Name == taskName);
                if (task == null)
                {
                    Console.WriteLine("Task not found.");
                    return;
                }

                task.Status = "Completed";
                Console.WriteLine($"Task '{taskName}' marked as completed in project '{projectName}'.");
            }

            public void TrackEmployeeHours(string employeeName, int hours)
            {
                Employee employee = Employees.FirstOrDefault(e => e.Name == employeeName);
                if (employee == null)
                {
                    Console.WriteLine("Employee not found.");
                    return;
                }

                employee.TotalHoursWorked += hours;
                Console.WriteLine($"Added {hours} hours to employee '{employeeName}'. Total hours: {employee.TotalHoursWorked}");
            }
        }

        public class Project
        {
            public string Name { get; set; }
            public List<Task> Tasks { get; set; }
        }

        public class Task
        {
            public string Name { get; set; }
            public string Status { get; set; }
            public Employee AssignedEmployee { get; set; }
        }

        public class Employee
        {
            public string Name { get; set; }
            public int TotalHoursWorked { get; set; }
        }
    }
}
