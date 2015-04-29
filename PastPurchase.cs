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
    public partial class PastPurchase : Form
    {
        public PastPurchase()
        {
            InitializeComponent();
        }

        private void PastPurchase_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string custID = textBox1.Text;
            if (radioButton1.Checked)
            {
                string choice = "item";
                PastPurchaseReport next = new PastPurchaseReport(choice, custID);
                next.Show();
                this.Hide();
            }
            else if (radioButton2.Checked)
            {
                string choice = "dates";
                PastPurchaseReport next = new PastPurchaseReport(choice, custID);
                next.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin next = new Admin();
            next.Show();
            this.Hide();
        }
    }
}
