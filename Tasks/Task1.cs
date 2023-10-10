using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tasks
{
    public partial class Task1 : Form
        
    {
        private int countdownValue;
        public Task1()
        {
            InitializeComponent();
        }

        private void Task1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int countdownValue) && int.TryParse(textBox2.Text, out int stepNumber))
            {

                richTextBox1.Text = countdownValue.ToString();
                timer1.Start();


            }
            else
            {
                richTextBox1.Text = "Please enter a valid number."+ " " + "Invalid Input Make sure all fields have been filled in" ;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
            
        {
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int countdownNumber) && int.TryParse(textBox2.Text, out int stepNumber))
            {
                // Start the countdown
                for (int i = countdownNumber; i >= 0; i--)
                {
                    richTextBox1.Text += $"Countdown: {i}" + " " +  "Countdown" + "\n";
                    Thread.Sleep(stepNumber * 1000);
                    richTextBox1.Text += $"Wating {stepNumber} seconds" + "\n";

                }
            }
            else
            {
                richTextBox1.Text = "Please enter a valid number."+ " " + "Invalid Input Make sure all fields have been filled in";
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while (this.countdownValue != 0)
            {
                int countdownValue = int.Parse(textBox1.Text);
                countdownValue = countdownValue - 1;
                richTextBox1.Text = countdownValue.ToString();
            }
            

            if (countdownValue <= 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("Countdown complete!");
            }

        }
    }
}
