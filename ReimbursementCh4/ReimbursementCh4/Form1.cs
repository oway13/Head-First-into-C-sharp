using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReimbursementCh4
{
    public partial class Form1 : Form
    {

        int startingMileage, endingMileage;
        double milesTraveled, amountOwed;
        double reimburseRate = 0.39;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startingMileage = (int) numericUpDown1.Value;
            endingMileage = (int)numericUpDown2.Value;
            if(startingMileage > endingMileage)
            {
                MessageBox.Show("The starting mileage must be less than the ending mileage.", "Cannot Calculate");
            }
            else
            {
                milesTraveled = endingMileage - startingMileage;
                amountOwed = milesTraveled * reimburseRate;
                label4.Text = "$" + amountOwed;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(milesTraveled + "miles", "Miles Traveled");
        }
    }
}
