using Jace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    public partial class Task3 : Form
    {
        public Task3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* create empty array, break string up push into array, valate if between 1-10, is an integer (Account for whitespace)
             * otherwise break loop and message show reason for fail
             * 
             * 
             */


            CalculationEngine engine = new CalculationEngine();
                double result = engine.Calculate(textBox1.Text);
                MessageBox.Show("Result: " + result);
            
        }
    }
}
