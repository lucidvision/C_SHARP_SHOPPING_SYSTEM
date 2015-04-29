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
    public partial class Cust : Form
    {
        public Cust()
        {
            InitializeComponent();
        }

        private void Cust_Load(object sender, EventArgs e)
        {

        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePurchaseOrder next = new CreatePurchaseOrder();
            next.Show();
            this.Hide();
        }

        private void reviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustPastPurchase next = new CustPastPurchase();
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
