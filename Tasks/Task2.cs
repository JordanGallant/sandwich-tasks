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
    public partial class Task2 : Form
    {

        class Person {

            //declaring public variables for the person object
            public string Name { get; set; }   
            public string Surname { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }

            //person object constructor
            public Person(string name, string surname, int age, string gender)
            {
                Name = name;
                Surname = surname; 
                Age = age;
                Gender = gender;
            }

        
        }


        public Task2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
