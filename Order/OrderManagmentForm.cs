using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace POO_25453_TP
{
    public partial class OrdersManagementForm : Form
    {
        private List<Order> orders;

        public OrdersManagementForm()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            dgvOrders.Columns.Clear(); // Limpa as colunas existentes

            // Adiciona as colunas com os nomes corretos
            dgvOrders.Columns.Add("OrderID", "Order ID");
            dgvOrders.Columns.Add("ClientID", "Client ID");
            dgvOrders.Columns.Add("ProductID", "Product ID");
            dgvOrders.Columns.Add("Quantity", "Quantity");
            dgvOrders.Columns.Add("UnitPrice", "Unit Price");
            dgvOrders.Columns.Add("TotalPrice", "Total Price");
            dgvOrders.Columns.Add("Status", "Status");

            // Carrega os dados dos pedidos
            string ordersFile = @"C:\PROGRAM_CS\25453_TP_POO\Order\orders.txt";

            if (File.Exists(ordersFile))
            {
                var orders = File.ReadAllLines(ordersFile)
                    .Select(line =>
                    {
                        var parts = line.Split(',');

                        return new
                        {
                            OrderID = int.Parse(parts[0]),
                            ClientID = int.Parse(parts[1]),
                            ProductID = int.Parse(parts[2]),
                            Quantity = int.Parse(parts[3]),
                            UnitPrice = int.Parse(parts[4]),
                            TotalPrice = int.Parse(parts[5]),
                            Status = parts[6]
                        };
                    });

                foreach (var order in orders)
                {
                    dgvOrders.Rows.Add(
                        order.OrderID,
                        order.ClientID,
                        order.ProductID,
                        order.Quantity,
                        order.UnitPrice,
                        order.TotalPrice,
                        order.Status
                    );
                }
            }
            else
            {
                MessageBox.Show($"O arquivo {ordersFile} não existe. Por favor, verifique o diretório.", "Arquivo Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private void btnMarkAsShipped_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var selectedRow = dgvOrders.SelectedRows[0];
                int orderId = int.Parse(selectedRow.Cells["OrderID"].Value.ToString());

                string ordersFile = @"C:\PROGRAM_CS\25453_TP_POO\Order\orders.txt";

                if (File.Exists(ordersFile))
                {
                    var orders = File.ReadAllLines(ordersFile).ToList();

                    for (int i = 0; i < orders.Count; i++)
                    {
                        var parts = orders[i].Split(',');

                        if (int.Parse(parts[0]) == orderId)
                        {
                            if (parts[6] == "Pending")
                            {
                                parts[6] = "Shipped";
                                orders[i] = string.Join(",", parts);
                                File.WriteAllLines(ordersFile, orders);
                                LoadOrders();
                                MessageBox.Show($"Pedido {orderId} marcado como 'Shipped'.", "Pedido Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("O pedido selecionado já foi enviado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"O arquivo {ordersFile} não existe. Por favor, verifique o diretório.", "Arquivo Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um pedido para atualizar.", "Nenhum Pedido Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void OrdersManagementForm_Load(object sender, EventArgs e)
        {

        }
    }
}
