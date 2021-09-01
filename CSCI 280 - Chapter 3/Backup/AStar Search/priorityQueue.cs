// I don't care about performance, just readability and ease of coding

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


// Written by Denny Bobeldyk, Summer 2010

namespace AStar_Search
{
    class priorityQueue
    {

        // Going to use an arraylist, the 0th element will be the highest priority, while the last element will be the lowest
        ArrayList q = new ArrayList();

        public int isPresent(node checkNode)
        {
            int counter = 0;
            foreach (node n in q)
            {
             
                if ((n.x == checkNode.x) && (n.y == checkNode.y))
                {
                    return counter;
                }

            }
            return -1;


        }

        public node getNode(int index)
        {
            node tempNode = (node) q[index];
            return tempNode;
        }

        public bool removeNode(int index){
            try
            {
                q.RemoveAt(index);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool enQueue(node insertNode)
        {
            int counter = 0;
            // If it's empty
            if (q.Count == 0)
            {
                q.Add(insertNode);
                return true;
            }
            else
            {
                // We need to find the best place to insert it
             
                bool inserted = false;
                foreach (node n in q)
                {
                  
                    if (insertNode.f < n.f)
                    {
                        // insert node here
                        q.Insert(counter, insertNode);
    
                        return true;
                    }
                    counter++;
                }
                // still not inserted, insert it at the end (we have the worst priority)
                if (!inserted)
                {
                    q.Add(insertNode);
                }
            }
            return true;



        }

        public node deQueue()
        {
            // just dequeue this one
            node outtaHere = (node)q[0]; 
            q.RemoveAt(0);
            return outtaHere;

        }

        public node peek()
        {
            return (node)q[0];
        }

        public bool isEmpty()
        {
            return (q.Count == 0);
        }
    }
}
