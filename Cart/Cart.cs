using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _25453_TP_POO
{
    public class Cart
    {
        // Properties of the Cart class
        public int CartId { get; set; }
        public Client Client { get; set; }
        public List<Product> Products { get; set; }

        // Path to the carts.txt file
        private static string cartsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Cart\carts.txt");

        // Constructor to initialize a Cart object
        public Cart(int cartId, Client client)
        {
            CartId = cartId;
            Client = client;
            Products = new List<Product>();
        }
    }
}