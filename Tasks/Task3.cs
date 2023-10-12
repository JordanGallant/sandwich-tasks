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
using System.Text.RegularExpressions;
using System.Linq.Expressions;

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
            var numberRegex = new Regex(@"^(10|[1-9])$"); //regular expressions @ - treat expression as is -  \d+ numbers 1-10 and no letters
            var matches = numberRegex.Matches(textBox1.Text); // creates an array of all integers from 1-10

            foreach ( var match in matches ) //looping through the matches array
            {
                if (int.TryParse(match.ToString() , out int num) && num >= 1 && num <= 10)
                {
                    CalculationEngine engine = new CalculationEngine();
                    double result = engine.Calculate(textBox1.Text);
                    MessageBox.Show("Result: " + result);

                }
                else
                {
                    MessageBox.Show("Please enter an Integer between 1-10");
                }
            }


            
            
        }
    }
}
