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
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Tasks
{
    public partial class Task1 : Form
        
    {

        public bool ValidateTextBoxValues(string textBox1Text, string textBox2Text, out int countdownNumber, out int stepNumber) //trying to implement the user valadation as a method
        {
            countdownNumber = 0;
            stepNumber = 0;
            if (int.TryParse(textBox1Text, out countdownNumber) && int.TryParse(textBox2Text, out stepNumber) && countdownNumber > stepNumber)
            {
                return true;
            }
            else
            {
                richTextBox1.Text = "Please enter a valid number." + " " + "Invalid Input Make sure all fields have been filled in \n Please note that the step number cannot be higher than the input number";
                return false;
            }
        }

        public Task1()
        {
            InitializeComponent();
        }
        //setting timer variables
        private int countdownValue = 0;
        private int stepNumber = 0;


        private void Task1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (int.TryParse(textBox1.Text, out int countdownValue) && int.TryParse(textBox2.Text, out int stepNumber) && int.Parse(textBox1.Text) > int.Parse(textBox2.Text))
            {
                //base value for text box on button click
                richTextBox1.Text = $" Countdown:{countdownValue.ToString()} seconds \n" ;
                //setting timer varibale to user input
                countdownValue = int.Parse(textBox1.Text);
                //starting timer on button click
                timer1.Start();


            }
            else
            {
                //data valadation
                richTextBox1.Text = "Please enter a valid number."+ " " + "Invalid Input Make sure all fields have been filled in \n Please note that the step number cannot be higher than the input number" ;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
            
        {
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int countdownNumber) && int.TryParse(textBox2.Text, out int stepNumber) && int.Parse(textBox1.Text) > int.Parse(textBox2.Text))
            {
                // Loop for the method that isnt using a timer
                for (int i = countdownNumber; i >= 0; i -= stepNumber)
                {
                    richTextBox1.Text += $"Countdown: {i}" + " " +  "Countdown" + "\n";
                    //decrement user input by step and use the step value to add delay
                    richTextBox1.Text += $"Wating {stepNumber} seconds " + "\n";
                    //using asynchronis functions 
                    await Task.Delay(stepNumber*1000);
                    

                }
            }
            else
            {
                richTextBox1.Text = "Please enter a valid number."+ " " + "Invalid Input Make sure all fields have been filled in \n Please note that the step number cannot be higher than the input number";
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //clear button mainly used for testing purposes
            richTextBox1.Clear();
            timer1.Stop();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            //setting timer variables to the user input
            countdownValue = int.Parse(textBox1.Text);
            stepNumber = int.Parse(textBox2.Text);
            //wile the timer varibale is not 0
            while (countdownValue > 0)
            {
                //decrement user input by step and use the step value to add delay
                countdownValue-= stepNumber;
                richTextBox1.Text += $" Count Down: {countdownValue}" + " seconds" + "\n";
                richTextBox1.Text += $"Waiting {stepNumber} seconds" + "\n";
                await Task.Delay(stepNumber*1000);
                
            }
           
            timer1.Stop();
            

        }
    }
}
