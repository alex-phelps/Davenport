using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;


// Written by Denny Bobeldyk, Summer 2010

// Need to make the obstructions work properly, it seems two of them get overwritten


namespace AStar_Search
{
    public partial class mainForm : Form
    {
        node goalNode = new node(0, 0);
        node startNode = new node(0, 0);
        List<node> obstacles = new List<node>(); // holds all 'X' obstacle nodes
        private const double MIN_COST = 1.0;
        private const double ALPHA = 0.5;
        private const int matrixWidth = 5;
        private const int matrixHeight = 5;

        priorityQueue openList = new priorityQueue();
        priorityQueue closedList = new priorityQueue();

        string[,] matrix;

        public mainForm()
        {
            InitializeComponent();

            clearBoard();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            this.startNodeXCB.SelectedIndex = 0;
            this.startNodeYCB.SelectedIndex = 3;

            this.goalNodeXCB.SelectedIndex = 4;
            this.goalNodeYCB.SelectedIndex = 4;

            this.obstaclesCountCB.SelectedIndex = 0;
        }

        // Calculates the estimate of getting from the node passed in to the goal node
        // Currently using the manhattan distance
        private double calc_h(node n)
        {
            double h;

            h = (double)(MIN_COST * Math.Abs((double)n.x - (double)goalNode.x)) +
                Math.Abs((double)n.y - (double)goalNode.y);

            return h;
        }

        private double calc_g(node n)
        {
            double g;
            g = 1.0 * ALPHA * (n.g - 1.0);

            return g;

        }

        // This is a bit nicer
        private void clearBoard()
        {
            matrix = new string[matrixWidth, matrixHeight];

            matrix[0, 0] = "";
            matrix[0, 1] = "";
            matrix[0, 2] = "";
            matrix[0, 3] = "";
            matrix[0, 4] = "";

            matrix[1, 0] = "";
            matrix[1, 1] = "";
            matrix[1, 2] = "";
            matrix[1, 3] = "";
            matrix[1, 4] = "";

            matrix[2, 0] = "";
            matrix[2, 1] = "";
            matrix[2, 2] = "";
            matrix[2, 3] = "";
            matrix[2, 4] = "";

            matrix[3, 0] = "";
            matrix[3, 1] = "";
            matrix[3, 2] = "";
            matrix[3, 3] = "";
            matrix[3, 4] = "";

            matrix[4, 0] = "";
            matrix[4, 1] = "";
            matrix[4, 2] = "";
            matrix[4, 3] = "";
            matrix[4, 4] = "";
        }

        private void showBestPath(node walker)
        {
            listBox1.Items.Clear();
            write("Found it: " + walker.x.ToString() + ", " + walker.y.ToString());
            node temp = walker;

            setNodes();

            while (temp.parent != null)
            {
                //int index = closedList.isPresent(temp.parent);
                //temp = closedList.getNode(index);

                temp = temp.parent;
               
                write("From: " + temp.x.ToString() + ", " + temp.y.ToString());
                if (temp.parent != null)
                {
                    matrix[temp.x, temp.y] = "*";
                }

            }
        }

        private void aStarButton_Click(object sender, EventArgs e)
        {
            node currentNode = new node();

            priorityQueue openList = new priorityQueue();
            priorityQueue closedList = new priorityQueue();
            
            listBox1.Items.Clear();
            write("Starting Node:" + startNode.x.ToString() + "  " + startNode.y.ToString());
            write("Starting to search...");

            openList.enQueue(startNode);

            while (!openList.isEmpty())
            {
                currentNode = openList.deQueue();
                closedList.enQueue(currentNode);

                if ((currentNode.x == goalNode.x) && (currentNode.y == goalNode.y))
                {
                    // We're done! We found it!
                    write("Found it: " + currentNode.x.ToString() + ", " + currentNode.y.ToString());
                    showBestPath(currentNode);
                    return;
                }
                else
                {
                    write("Testing " + currentNode.x.ToString() + ", " + currentNode.y.ToString());


                    ArrayList neighbors = getNeighbors(currentNode);

                    foreach (node n in neighbors)
                    {

                        // When comparing to the AI programming book, n = successor (p.42)
                        double estimatedCost = calc_h(n);
                        write("Checking Successor: " + n.x.ToString() + ", " + n.y.ToString() + " Estimated Cost = " + estimatedCost.ToString());
                        // Find the neighbor with the best path
                        n.h = estimatedCost;
                        n.g = currentNode.g + calc_g(n);
                        n.f = n.g + n.h;

                        // Check to see if it's present on the openList
                        int checkPresent = openList.isPresent(n);
                        // If it exists
                        if (checkPresent > -1)
                        {
                            // if it is present, check to see who has the best 'f' value
                            node temp = openList.getNode(checkPresent);
                            if (temp.f < n.f)
                            {
                                // remove temp from open list
                                openList.removeNode(checkPresent);
                                continue;
                            }
                        }
                        
                        // Check to see if it's present on the closedList
                        int checkClosed = closedList.isPresent(n);

                        if (checkClosed > -1)
                        {
                            node temp2 = closedList.getNode(checkClosed);
                            if (temp2.f < n.f)
                            {
                                closedList.removeNode(checkClosed);
                                continue;
                            }
                        }
                        

                        if (checkPresent > -1)
                        {
                            openList.removeNode(checkPresent);
                        }
                        
                        if (checkClosed > -1)
                        {
                            closedList.removeNode(checkClosed);
                        }

                        n.parent = currentNode;
                        openList.enQueue(n);

                    }

                }

            }

            write("Failed to reach goal!");
        }


        // returns the neighbors of the node passed in. we can only move north/south/west/east, no diagonols
        // some of the neighbors may be blocked by walls/obstacles
        private ArrayList getNeighbors(node n)
        {
            ArrayList neighbors = new ArrayList();

            //Check South neighbor
            if (n.y + 1 < matrixHeight)
            {
                if (matrix[n.x, n.y + 1] != "X")
                {
                    neighbors.Add(new node(n.x, n.y + 1));
                }
            }

            // Check North neighbor
            if (n.y - 1 >= 0)
            {
                if (matrix[n.x, n.y - 1] != "X")
                {
                    neighbors.Add(new node(n.x, n.y - 1));
                }
            }

            // Check West Neighbor
            if (n.x - 1 >= 0)
            {
                if (matrix[n.x - 1, n.y] != "X")
                {
                    neighbors.Add(new node(n.x - 1, n.y));
                }
            }

            // Check East Neighbor
            if (n.x + 1 < matrixWidth)
            {
                if (matrix[n.x + 1, n.y] != "X")
                {
                    neighbors.Add(new node(n.x + 1, n.y));
                }
            }
            return neighbors;

        }

        private void write(String s)
        {
            listBox1.Items.Add(s);
        }


        private void goalNodeXCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // These are intially set to -1, so need a check in here
            if ((goalNodeXCB.SelectedIndex > -1) && (goalNodeYCB.SelectedIndex > -1))
            {
                goalNode.x = goalNodeXCB.SelectedIndex;
                goalNode.y = goalNodeYCB.SelectedIndex;
                setNodes();
            }
        }

        private void goalNodeYCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // These are intially set to -1, so need a check in here
            if ((goalNodeXCB.SelectedIndex > -1) && (goalNodeYCB.SelectedIndex > -1))
            {
                goalNode.x = goalNodeXCB.SelectedIndex;
                goalNode.y = goalNodeYCB.SelectedIndex;
                setNodes();
            }
        }

        private void startNodeXCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((startNodeXCB.SelectedIndex > -1) && (startNodeYCB.SelectedIndex > -1))
            {
                startNode.x = startNodeXCB.SelectedIndex;
                startNode.y = startNodeYCB.SelectedIndex;
                setNodes();
            }
        }

        private void startNodeYCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((startNodeXCB.SelectedIndex > -1) && (startNodeYCB.SelectedIndex > -1))
            {
                startNode.x = startNodeXCB.SelectedIndex;
                startNode.y = startNodeYCB.SelectedIndex;
                setNodes();
            }
        }

        private void obstaclesCountCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (obstaclesCountCB.SelectedIndex > -1)
            {
                // Randomize X number of obstacles

                obstacles.Clear();

                Random rand = new Random();
                int length = (int)Math.Sqrt(matrix.Length);
                for (int i = 0; i < obstaclesCountCB.SelectedIndex; i++)
                {
                    obstacles.Add(new node(rand.Next(0, length), rand.Next(0, length)));
                }

                setNodes();
            }
        }

        private void displayGraphButton_Click(object sender, EventArgs e)
        {
            graphDisplay gd = new graphDisplay(matrix);

            gd.ShowDialog();

        }

        private void setNodes()
        {
            clearBoard();

            matrix[startNode.x, startNode.y] = "S"; // Start node
            matrix[goalNode.x, goalNode.y] = "G"; // Goal node

            // Obstacle nodes
            foreach (node n in obstacles)
            {
                if (matrix[n.x, n.y] != "S" && matrix[n.x, n.y] != "G") // Do not override start or goal
                {
                    matrix[n.x, n.y] = "X";
                }
            }
        }
    }


}

