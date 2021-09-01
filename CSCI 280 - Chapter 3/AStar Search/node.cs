using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


// Written by Denny Bobeldyk, Summer 2010

namespace AStar_Search
{
    class node
    {
        public node parent;
        public double g;
        public double h;
        public double f;

        public int x;
        public int y;


        public node()
        {
            g = 0.0;
            h = 0.0;
            f = 0.0;
            x = 0;
            y = 0;
        }

        public node(int varX, int varY)
        {
            g = 0.0;
            h = 0.0;
            f = 0.0;
            x = varX;
            y = varY;
        }


       
    }
}
