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
    public partial class CustPastPurchaseReport : Form
    {
        public CustPastPurchaseReport(string choice)
        {
            InitializeComponent();
            string query;
            if (choice.Equals("item"))
            {
                query = "SELECT bcpark354.OrderDetail.ItemID, bcpark354.PurchaseOrder.CustomerID, bcpark354.PurchaseOrder.OrderID, bcpark354.PurchaseOrder.OrderDate, bcpark354.OrderDetail.Qty FROM bcpark354.PurchaseOrder INNER JOIN bcpark354.OrderDetail ON bcpark354.PurchaseOrder.OrderID=bcpark354.OrderDetail.OrderID WHERE bcpark354.PurchaseOrder.CustomerID = " +Program.custID+ " ORDER BY bcpark354.OrderDetail.ItemID";
                DBConnect con = new DBConnect();
                con.OpenConnection();
                SqlDataReader Data = con.getData(query);
                List<string> purchases = new List<string>();
                try
                {
                    while (Data.Read())
                    {
                        purchases.Add("ItemID: "+Data["ItemID"] + " -OrderID: " + Data["OrderID"] + " -CustomerID: " + Data["CustomerID"] + " -OrderDate: " + Data["OrderDate"] + " -Quantity: " + Data["Qty"]);
                    }

                    listBox1.DataSource = purchases;
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message, "Failed to Produce Report", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else if(choice.Equals("dates"))
            {
                query = "SELECT bcpark354.PurchaseOrder.OrderDate, bcpark354.OrderDetail.ItemID, bcpark354.PurchaseOrder.CustomerID, bcpark354.PurchaseOrder.OrderID, bcpark354.OrderDetail.Qty FROM bcpark354.PurchaseOrder INNER JOIN bcpark354.OrderDetail ON bcpark354.PurchaseOrder.OrderID=bcpark354.OrderDetail.OrderID  WHERE bcpark354.PurchaseOrder.CustomerID = " +Program.custID+ " ORDER BY bcpark354.PurchaseOrder.DeliveryDate";
                DBConnect con = new DBConnect();
                con.OpenConnection();
                SqlDataReader Data = con.getData(query);
                List<string> purchases = new List<string>();
                try
                {
                    while (Data.Read())
                    {
                        purchases.Add("OrderDate: "+Data["OrderDate"] + " -ItemID: " + Data["ItemID"] + " -CustomerID: " + Data["CustomerID"] + " -OrderID: " + Data["OrderID"] + " -Quantity: "+ Data["Qty"]);
                    }

                    listBox1.DataSource = purchases;
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message, "Failed to Produce Report", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void CustPastPurchaseReport_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            CustPastPurchase next = new CustPastPurchase();
            next.Show();
            this.Hide();
        }
    }
}
