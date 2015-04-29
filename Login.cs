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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("9999"))
            {
                Admin next = new Admin();
                MessageBox.Show("Welcome Admin");
                next.Show();
                this.Hide();
            }
            else if (textBox1.TextLength > 4)
            {
                MessageBox.Show(textBox1.Text, "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                DBConnect con = new DBConnect();
                con.OpenConnection();
                try
                {
                    string query = "SELECT * FROM bcpark354.Customer";
                    SqlDataReader Data = con.getData(query);
                    while (Data.Read())
                    {
                        if (textBox1.Text.Equals(Data["CustomerID"].ToString()))
                        {
                            Program.custID = textBox1.Text;
                            Cust next = new Cust();
                            MessageBox.Show("Welcome Customer");
                            next.Show();
                            this.Hide();
                        }
                    }
                    Data.Close();
                    con.CloseConnection();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Customer Retrival Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {

        }
    }
}
