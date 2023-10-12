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
        /* Explination:
         * Tree data structure that stores a Person Object in a node
         * Tree data structures are non linear,
         * in this case we have to use a non linear data structure as we are showing the relationship between heiracal relationships
         * 
         * A person will be represented by a tree node and each node will have at least 1 children node
         * 
         * 
         */

        class Person {

            //declaring public variables for the person object that will be stored in a single tree node.
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

        class TreeNode

        {
            //Data of the person object that will be stored in each node, name age, gender etc.
            public Person Data { get; set; }
            //a list of children will also be stored in each node initialized as an empty array.
            public List<TreeNode> Children { get; set; }    
            
            //tree node constructor 
            public TreeNode(Person data) 
            { 
                Data = data;
                Children = new List<TreeNode>();
            }

            //this method adds a new child to a node
            public void AddChild(TreeNode child)
            {
                Children.Add(child);
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
