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
    public partial class CreateCust : Form
    {
        public CreateCust()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnect con = new DBConnect();
            con.OpenConnection();
            string query = "insert into bcpark354.Customer(CustomerID, Name, Address, AccountBalance)";
            SqlDataAdapter Da = new SqlDataAdapter();
            try
            {

                Da.InsertCommand = new SqlCommand(query + "values (@CustomerID, @Name, @Address, @AccountBalance)", con.connection);
                Da.InsertCommand.Parameters.Add("@CustomerID", SqlDbType.Char).Value = textBox1.Text;
                Da.InsertCommand.Parameters.Add("@Name", SqlDbType.Char).Value = textBox2.Text;
                Da.InsertCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = textBox3.Text;
                Da.InsertCommand.Parameters.Add("@AccountBalance", SqlDbType.Decimal).Value = decimal.Parse(textBox4.Text);
                Da.InsertCommand.ExecuteNonQuery();

                MessageBox.Show("The customer has been entered into the system");
            }
            catch (Exception q)
            {
                MessageBox.Show(q.Message, "Could not create customer", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            con.CloseConnection();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin next = new Admin();
            next.Show();
            this.Hide();
        }
    }
}
