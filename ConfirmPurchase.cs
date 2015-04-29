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
    public partial class ConfirmPurchase : Form
    {
        public string pItem;
        public string pQuantity;
        public DateTime pDate;
        public decimal UnitPriceVar;
        public DateTime nDate = DateTime.Now;
        public decimal total, funds;


        public ConfirmPurchase(string item, string quantity, string date)
        {
            InitializeComponent();
            pItem = item;
            pQuantity = quantity;
            pDate = DateTime.Parse(date);
            textBox1.Text = item + " " + quantity + " " + date;
          
        }
        private void ConfirmPurchase_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            DBConnect con = new DBConnect();
            con.OpenConnection();
            string itemIDvar = pItem.Substring(8,4);
            string Mquery = "select ListPrice from bcpark354.Merchandise where ItemID =" + itemIDvar;
            string Cquery = "select * from bcpark354.PurchaseOrder";
            string Xquery = "select AccountBalance from bcpark354.Customer where CustomerID =" + Program.custID;
            string Pquery = "Insert into bcpark354.PurchaseOrder(OrderID, CustomerID, DeliveryDate, OrderDate)";
            string Oquery = "Insert into bcpark354.OrderDetail(OrderID, ItemID, UnitPrice, Qty)";
            string Tquery = "update bcpark354.Customer set AccountBalance = @AccountBalance where CustomerID =" + Program.custID;
            MessageBox.Show(itemIDvar);

            SqlDataReader Data = con.getData(Cquery);
            try
            {
                while (Data.Read())
                {
                    count++;
                }
                Data.Close();
                count++;
            }

            catch (Exception w)
            {
                MessageBox.Show(w.Message, "Could not produce orderID", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            SqlDataReader Data2 = con.getData(Mquery);
            try
            {
                while (Data2.Read())
                {
                    UnitPriceVar = Data2.GetDecimal(0);
                }
                Data2.Close();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message, "Could not produce orderID", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            SqlDataReader Data3 = con.getData(Xquery);
            try
            {
                while (Data3.Read())
                {
                    funds = Data3.GetDecimal(0);
                }
                Data3.Close();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message, "Could not produce orderID", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            total = UnitPriceVar * decimal.Parse(pQuantity);

            if (funds >= total)
            {
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlDataAdapter Ha = new SqlDataAdapter();
                SqlDataAdapter Ca = new SqlDataAdapter();

                try
                {
                    Da.InsertCommand = new SqlCommand(Pquery + "values (@OrderID, @CustomerID, @DeliveryDate, @OrderDate)", con.connection);
                    Da.InsertCommand.Parameters.Add("@OrderID", SqlDbType.Char).Value = count.ToString();
                    Da.InsertCommand.Parameters.Add("@CustomerID", SqlDbType.Char).Value = Program.custID;
                    Da.InsertCommand.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = pDate.Date;
                    Da.InsertCommand.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = nDate.Date;
                    Da.InsertCommand.ExecuteNonQuery();

                    Ha.InsertCommand = new SqlCommand(Oquery + "values (@OrderID, @ItemID, @UnitPrice, @Qty)", con.connection);
                    Ha.InsertCommand.Parameters.Add("@OrderID", SqlDbType.Char).Value = count.ToString();
                    Ha.InsertCommand.Parameters.Add("@ItemID", SqlDbType.Char).Value = itemIDvar;
                    Ha.InsertCommand.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = total;
                    Ha.InsertCommand.Parameters.Add("@Qty", SqlDbType.Int).Value = int.Parse(pQuantity);
                    Ha.InsertCommand.ExecuteNonQuery();

                    Ca.UpdateCommand = new SqlCommand(Tquery, con.connection);
                    Ca.UpdateCommand.Parameters.Add("@AccountBalance", SqlDbType.Decimal).Value = (funds - total);
                    Ca.UpdateCommand.ExecuteNonQuery();

                    MessageBox.Show("Your order as been entered into the system. Thank You");

                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Could not confirm order", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Sorry, you do not have enough funds for that purchase");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreatePurchaseOrder next = new CreatePurchaseOrder();
            next.Show();
            this.Hide();
        }
    }
}