using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void createCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateCust next = new CreateCust();
            next.Show();
            this.Hide();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCustomer next = new UpdateCustomer();
            next.Show();
            this.Hide();
        }

        private void pastPurchasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PastPurchase next = new PastPurchase();
            next.Show();
            this.Hide();
        }

        private void totalPurchasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TotalPurchaseOrders next = new TotalPurchaseOrders();
            next.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login next = new Login();
            next.Show();
            this.Hide();
        }
    }
}
