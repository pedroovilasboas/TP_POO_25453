using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _25453_TP_POO
{
    public class Cart
    {
        // Atributos da classe Cart
        public int CartId { get; set; }
        public Client Client { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal TotalPrice { get; private set; }

        // Caminho para o arquivo cart.txt para persistência
        private static string cartFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Cart\cart.txt");

        // Construtor
        public Cart(int cartId, Client client)
        {
            CartId = cartId;
            Client = client;
            CalculateTotal();
        }

        // Método para adicionar produto ao carrinho
        public void AddToCart(Product product)
        {
            Products.Add(product);
            CalculateTotal();
        }

        // Método para remover produto do carrinho
        public void RemoveFromCart(Product product)
        {
            Products.Remove(product);
            CalculateTotal();
        }

        // Método para calcular o preço total do carrinho
        public void CalculateTotal()
        {
            TotalPrice = Products.Sum(p => p.Price);
        }

        // Método para limpar o carrinho
        public void ClearCart()
        {
            Products.Clear();
            CalculateTotal();
        }

        // Método para finalizar a compra (checkout)
        public Order Checkout()
        {
            var order = new Order(GetNextOrderId(), Client, DateTime.Now, "Por Enviar")
            {
                Products = new List<Product>(Products)
            };
            order.CalculateTotal();
            order.Save();

            // Limpar o carrinho após a finalização da compra
            ClearCart();

            return order;
        }

        // Método para salvar o estado do carrinho no arquivo
        public void Save()
        {
            var carts = LoadCart();
            carts.Add(this);
            SaveCarts(carts);
        }

        // Método para carregar o carrinho do arquivo
        public static List<Cart> LoadCart()
        {
            var carts = new List<Cart>();

            if (File.Exists(cartFile))
            {
                var lines = File.ReadAllLines(cartFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length > 2)
                    {
                        int cartId = int.Parse(parts[0]);
                        var client = new Client(parts[1]); // Simplificado para exemplo
                        var cart = new Cart(cartId, client);
                        carts.Add(cart);
                    }
                }
            }

            return carts;
        }

        // Método para salvar uma lista de carrinhos no arquivo
        public static void SaveCarts(List<Cart> carts)
        {
            using (var writer = new StreamWriter(cartFile))
            {
                foreach (var cart in carts)
                {
                    writer.WriteLine($"{cart.CartId},{cart.Client},{cart.TotalPrice}");
                }
            }
        }

        // Método para obter o próximo ID de ordem (simples para exemplo)
        private static int GetNextOrderId()
        {
            var orders = Order.LoadOrders();
            return orders.Count > 0 ? orders.Max(o => o.OrderId) + 1 : 1;
        }
    }
}