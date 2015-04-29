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
    public partial class CreatePurchaseOrder : Form
    {
        public CreatePurchaseOrder()
        {
            InitializeComponent();

            try
            {
                DBConnect con = new DBConnect();
                con.OpenConnection();
                string query = "SELECT * FROM bcpark354.Merchandise ";
                SqlDataReader Data = con.getData(query);
                List<string> items = new List<string>();
                while (Data.Read())
                {
                    items.Add("ItemID: "+Data["ItemID"]+" - Name: "+Data["Name"]+ " - Description: "+Data["Description"]+" - ListPrice: "+Data["ListPrice"].ToString());
                }
                listBox1.DataSource = items;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Failed to Populate Merchandise", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string item = listBox1.Items[index].ToString();
            string quantity = textBox1.Text;
            try
            {
                int.Parse(textBox1.Text);
                DateTime.Parse(textBox2.Text);
                string date = textBox2.Text;
                ConfirmPurchase next1 = new ConfirmPurchase(item, quantity, date);
                next1.Show();
                this.Hide();
            }
            catch (FormatException q)
            {
                MessageBox.Show(q.Message, "Please enter a valid int or date (yyyy-mm-dd)");
                CreatePurchaseOrder next = new CreatePurchaseOrder();
                next.Show();
                this.Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
  
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cust next = new Cust();
            next.Show();
            this.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
