using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Person
{

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

    //this method adds a new child node using the built in array method add.
    public void AddChild(TreeNode child)
    {
        Children.Add(child);
    }
    //this method removes a new child node using the built in array method add.
    public void RemoveChild(TreeNode child)
    {
        Children.Remove(child);
    }
}
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


        public Task2()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            //setting up nodes
            TreeNode Root = new TreeNode(new Person("Jordan", "Gallant", 22, "Male"));

            TreeNode Parent1 = new TreeNode(new Person("Helen", "Gallant", 57, "Female"));
            TreeNode Parent2 = new TreeNode(new Person("Solly", "Gallant", 64, "Male"));

            TreeNode GrandparentLeft1 = new TreeNode(new Person("Vic", "Penrith", 69, "Male"));
            TreeNode GrandparentLeft2 = new TreeNode(new Person("Gill", "Penrith", 70, "Female"));

            TreeNode GrandparentRight1 = new TreeNode(new Person("Peter", "Gallant", 78, "Male"));
            TreeNode GrandparentRight2 = new TreeNode(new Person("Mary", "Gallant", 76, "Female"));


            //hard code family tree
            // adding Jordans Parents(Child nodes)
            Root.AddChild(Parent1);
            Root.AddChild(Parent2);
            //Adding Helen's Parents(Child nodes)
            Parent1.AddChild(GrandparentLeft1);
            Parent1.AddChild(GrandparentLeft2);
            //Adding Solly's Parents(Child nodes)
            Parent2.AddChild(GrandparentRight1);
            Parent2.AddChild(GrandparentRight2);

            DisplayFamilyTree(Root, 0);


            
        }
           static void DisplayFamilyTree(TreeNode node, int depth)
        {
            //shows the level of the tree using dashes (Not my code)
            MessageBox.Show(new string('-', depth*4)+ node.Data.Name + ", " + node.Data.Surname + ", " + node.Data.Age + ", " + node.Data.Gender); // node.Data represents the person object of that node
            foreach (var child in node.Children)  // O(n) linear time complexity -  looping through each child node (parent) 
            { 
                DisplayFamilyTree(child, depth+1); //recursion (Scary)
                // this will display each child node (parent) 
            }
        
        }

        private void Task2_Load(object sender, EventArgs e)
        {

        }
    }
}
