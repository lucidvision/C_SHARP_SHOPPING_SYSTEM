using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class TotalPurchaseOrders : Form
    {
        public TotalPurchaseOrders()
        {
            InitializeComponent();
            DBConnect con = new DBConnect();
            con.OpenConnection();
            string query = "SELECT bcpark354.PurchaseOrder.OrderDate, count(bcpark354.PurchaseOrder.OrderDate) as NumberOrders, SUM(bcpark354.OrderDetail.UnitPrice) as TotalSales FROM bcpark354.PurchaseOrder INNER JOIN bcpark354.OrderDetail ON bcpark354.PurchaseOrder.OrderID=bcpark354.OrderDetail.OrderID GROUP BY bcpark354.PurchaseOrder.OrderDate ORDER BY bcpark354.PurchaseOrder.OrderDate DESC";
            SqlDataReader Data = con.getData(query);
            List<string> purchases = new List<string>();
            try
            {
                while (Data.Read())
                {
                    purchases.Add("OrderDate: "+Data["OrderDate"] + " -NumberOfOrders: " + Data["NumberOrders"] + " -TotalSales: " + Data["TotalSales"]);
                }

                listBox1.DataSource = purchases;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Failed to Produce Report", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void TotalPurchaseOrders_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin next = new Admin();
            next.Show();
            this.Hide();
        }
    }
}
