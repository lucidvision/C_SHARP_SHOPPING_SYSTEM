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
    public partial class CustPastPurchase : Form
    {
        public CustPastPurchase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string choice = "item";
                CustPastPurchaseReport next = new CustPastPurchaseReport(choice);
                next.Show();
                this.Hide();
            }
            else if (radioButton2.Checked)
            {
                string choice = "dates";
                CustPastPurchaseReport next = new CustPastPurchaseReport(choice);
                next.Show();
                this.Hide();
            }
        }

        private void CustPastPurchase_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cust next = new Cust();
            next.Show();
            this.Hide();
        }
    }
}
