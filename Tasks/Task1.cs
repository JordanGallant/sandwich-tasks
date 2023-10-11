﻿using System;
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
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Tasks
{
    public partial class Task1 : Form
        
    {
        
        public Task1()
        {
            InitializeComponent();
        }
        private int countdownValue = 0;
        private int stepNumber = 0;


        private void Task1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int countdownValue) && int.TryParse(textBox2.Text, out int stepNumber))
            {

                richTextBox1.Text = $"Countdown: {countdownValue.ToString()}" + " " +"Countdown" + "\n" ;
                countdownValue = int.Parse(textBox1.Text);
                stepNumber = int.Parse(textBox2.Text);
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
                for (int i = countdownNumber; i >= 0; i -= stepNumber)
                {
                    richTextBox1.Text += $"Countdown: {i}" + " " +  "Countdown" + "\n";
                    richTextBox1.Text += $"Step is {stepNumber}" + "\n";

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
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (countdownValue > 0)
            {
                int output = countdownValue - stepNumber;
                richTextBox1.Text += $"Countdown: {output}" + " seconds" +"\n";
                richTextBox1.Text += $"Step is {stepNumber}" + "\n";
            }
            else
            {
                timer1.Stop();
                richTextBox1.Text = "Time is up!";
            }

        }
    }
}
