public class Order
{
    public int OrderID { get; set; }
    public int ClientID { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public string Status { get; set; }

    private static string ordersFile = "orders.txt";

    public static List<Order> LoadOrders()
    {
        if (!File.Exists(ordersFile)) return new List<Order>();

        return File.ReadAllLines(ordersFile)
            .Select(line =>
            {
                var parts = line.Split(',');
                return new Order
                {
                    OrderID = int.Parse(parts[0]),
                    ClientID = int.Parse(parts[1]),
                    ProductID = int.Parse(parts[2]),
                    Quantity = int.Parse(parts[3]),
                    Status = parts[4]
                };
            }).ToList();
    }

    public static void SaveOrders(List<Order> orders)
    {
        var lines = orders.Select(o => $"{o.OrderID},{o.ClientID},{o.ProductID},{o.Quantity},{o.Status}");
        File.WriteAllLines(ordersFile, lines);
    }
}
