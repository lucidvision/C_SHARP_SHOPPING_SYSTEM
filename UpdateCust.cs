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
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnect con = new DBConnect();
            con.OpenConnection();
            string query = "update bcpark354.Customer set Name = @Name, Address = @Address, AccountBalance = @AccountBalance where CustomerID = @CustomerID";
            SqlDataAdapter Da = new SqlDataAdapter();
            try
            {
                Da.UpdateCommand = new SqlCommand(query, con.connection);
                Da.UpdateCommand.Parameters.Add("@CustomerID", SqlDbType.Char).Value = textBox1.Text;
                Da.UpdateCommand.Parameters.Add("@Name", SqlDbType.Char).Value = textBox2.Text;
                Da.UpdateCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = textBox3.Text;
                Da.UpdateCommand.Parameters.Add("@AccountBalance", SqlDbType.Decimal).Value = decimal.Parse(textBox4.Text);
                Da.UpdateCommand.ExecuteNonQuery();
                MessageBox.Show("The customer has been updated");
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message, "Could not update customer", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

        private void UpdateCust_Load(object sender, EventArgs e)
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
