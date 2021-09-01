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

            // I'm not actually doing anything with the matrix yet
            matrix = new string[matrixWidth, matrixHeight];

            matrix[0, 0] = "";
            matrix[0, 1] = "";
            matrix[0, 2] = "";
            matrix[0, 3] = "";
            matrix[0, 4] = "";

            matrix[1, 0] = "";
            matrix[1, 1] = "X";
            matrix[1, 2] = "";
            matrix[1, 3] = "X";
            matrix[1, 4] = "";

            matrix[2, 0] = "";
            matrix[2, 1] = "X";
            matrix[2, 2] = "X";
            matrix[2, 3] = "X";
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

        private void mainForm_Load(object sender, EventArgs e)
        {
            this.startNodeXCB.SelectedIndex = 0;
            this.startNodeYCB.SelectedIndex = 3;

            this.goalNodeXCB.SelectedIndex = 4;
            this.goalNodeYCB.SelectedIndex = 4;



        }

        // Calculates the estimate of getting from the node passed in to the goal node
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

        private void showBestPath(node walker)
        {
            listBox1.Items.Clear();
            write("Found it: " + walker.x.ToString() + ", " + walker.y.ToString());
            node temp = walker;


            matrix = new string[matrixWidth, matrixHeight];

            matrix[0, 0] = "";
            matrix[0, 1] = "";
            matrix[0, 2] = "";
            matrix[0, 3] = "";
            matrix[0, 4] = "";

            matrix[1, 0] = "";
            matrix[1, 1] = "X";
            matrix[1, 2] = "";
            matrix[1, 3] = "X";
            matrix[1, 4] = "";

            matrix[2, 0] = "";
            matrix[2, 1] = "X";
            matrix[2, 2] = "X";
            matrix[2, 3] = "X";
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

            setStartNode(startNode.x, startNode.y);
            setGoalNode(goalNode.x, goalNode.y);

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
                    // we're done
                    // need to write out our path to here
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
                        write("Checking Successor: " + n.x.ToString() + ", " + n.y.ToString() + "Estimated Cost = " + estimatedCost.ToString());
                        // Find the neighbor with the best path
                        n.h = calc_h(n);
                        n.g = currentNode.g + calc_g(currentNode);
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

                        int loc = openList.isPresent(n);

                        if (loc > -1)
                        {
                            openList.removeNode(loc);
                        }

                        int loc2 = closedList.isPresent(n);

                        if (loc2 > -1)
                        {
                            closedList.removeNode(loc2);
                        }

                        n.parent = currentNode;
                        openList.enQueue(n);

                    }

                }

            }


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
                setGoalNode(goalNode.x, goalNode.y);
            }
        }

        private void goalNodeYCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // These are intially set to -1, so need a check in here
            if ((goalNodeXCB.SelectedIndex > -1) && (goalNodeYCB.SelectedIndex > -1))
            {
                goalNode.x = goalNodeXCB.SelectedIndex;
                goalNode.y = goalNodeYCB.SelectedIndex;
                setGoalNode(goalNode.x, goalNode.y);
            }
        }

        private void startNodeXCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((startNodeXCB.SelectedIndex > -1) && (startNodeYCB.SelectedIndex > -1))
            {
                startNode.x = startNodeXCB.SelectedIndex;
                startNode.y = startNodeYCB.SelectedIndex;
                setStartNode(startNode.x, startNode.y);
            }
        }

        private void startNodeYCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((startNodeXCB.SelectedIndex > -1) && (startNodeYCB.SelectedIndex > -1))
            {
                startNode.x = startNodeXCB.SelectedIndex;
                startNode.y = startNodeYCB.SelectedIndex;
                setStartNode(startNode.x, startNode.y);
            }
        }

        private void displayGraphButton_Click(object sender, EventArgs e)
        {
            graphDisplay gd = new graphDisplay(matrix);

            gd.ShowDialog();

        }

        private void setGoalNode(int varX, int varY)
        {
            for (int i = 0; i < matrixWidth; i++)
            {
                for (int j = 0; j < matrixHeight; j++)
                {
                    if (matrix[i, j] == "G")
                    {
                        // Set the old goal to nothing
                        matrix[i, j] = "";
                    }
                }
            }
            matrix[varX, varY] = "G";

        }


        private void setStartNode(int varX, int varY)
        {
            for (int i = 0; i < matrixWidth; i++)
            {
                for (int j = 0; j < matrixHeight; j++)
                {

                        if (matrix[i, j] == "S")
                        {
                            // Set the old start node to nothing
                            matrix[i, j] = "";
                        }
                }
            }
            matrix[varX, varY] = "S";

        }


    }


}

