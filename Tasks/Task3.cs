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

            if (Enumerable.Range(1, 10).Contains(int.Parse(textBox1.Text)))
            {
                CalculationEngine engine = new CalculationEngine();
                double result = engine.Calculate(textBox1.Text);
                MessageBox.Show("Result: " + result);
            }
            else
            {
                MessageBox.Show("Please enter a valid integer between 1 and 10");
            }
        }
    }
}
