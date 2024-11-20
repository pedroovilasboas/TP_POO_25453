using POO_25453_TP;

public class Order
{
    // Order class attributes
    public int OrderId { get; set; }
    public Client Client { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
    public decimal TotalPrice { get; private set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }

    // File path for orders.txt for persistence
    private static string ordersFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\POO_25453_TP\Order\orders.txt");

    // Constructor
    public Order(int orderId, Client client, DateTime orderDate, string status = "To Ship")
    {
        OrderId = orderId;
        Client = client;
        OrderDate = orderDate;
        Status = status;
        CalculateTotal();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        Products.Add(product);
        CalculateTotal();
    }

    // Method to calculate the total price of the order
    public void CalculateTotal()
    {
        TotalPrice = Products.Sum(p => p.Price);
    }

    // Method to save the order to file
    public void Save()
    {
        var orders = LoadOrders();
        orders.Add(this);
        SaveOrders(orders);
    }

    // Method to save a list of orders to file
    public static void SaveOrders(List<Order> orders)
    {
        using (var writer = new StreamWriter(ordersFile))
        {
            foreach (var order in orders)
            {
                // Convert Products to a single string separated by ';' (e.g., "Product1:Price;Product2:Price")
                string productsData = string.Join(";", order.Products.Select(p => p.ToString()));

                // Save as "OrderId,Username,Products,TotalPrice,OrderDate,Status"
                writer.WriteLine($"{order.OrderId},{order.Client.Username},{productsData},{order.TotalPrice},{order.OrderDate},{order.Status}");
            }
        }
    }

    // Method to load orders from file
    public static List<Order> LoadOrders()
    {
        var orders = new List<Order>();

        if (File.Exists(ordersFile))
        {
            var lines = File.ReadAllLines(ordersFile);
            var clients = Client.LoadClients(); // Load all clients to search by username

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length >= 6) // Make sure we have all required parts
                {
                    int orderId = int.Parse(parts[0]);
                    string username = parts[1];
                    string productsData = parts[2];
                    decimal totalPrice = decimal.Parse(parts[3]);
                    DateTime orderDate = DateTime.Parse(parts[4]);
                    string status = parts[5];

                    // Find the client by username
                    var client = clients.FirstOrDefault(c => c.Username == username);
                    if (client != null)
                    {
                        var order = new Order(orderId, client, orderDate, status)
                        {
                            TotalPrice = totalPrice
                        };

                        // Load each product from the products data (split by ';')
                        foreach (var productData in productsData.Split(';'))
                        {
                            var productParts = productData.Split(':');
                            if (productParts.Length == 2)
                            {
                                string productName = productParts[0];
                                decimal productPrice = decimal.Parse(productParts[1]);

                                // Create a product with the name and price (this assumes other details are not essential here)
                                var product = new Product(null, null, productName, "", "", productPrice, 0);
                                order.Products.Add(product);
                            }
                        }

                        orders.Add(order);
                    }
                }
            }
        }

        return orders;
    }
}
