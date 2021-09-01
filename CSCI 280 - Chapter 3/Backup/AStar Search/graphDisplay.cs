using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AStar_Search
{
    public partial class graphDisplay : Form
    {
        public graphDisplay(string[,] matrix)
        {


            InitializeComponent();
            if (matrix.Length > 100)
            {
                throw new System.Exception("Exceeded maximum matrix size");
            }
            else
            {

                for (int i = 0; i < Math.Sqrt(matrix.Length); i++)
                {
                    for (int j = 0; j < Math.Sqrt(matrix.Length); j++)
                    {
                        TextBox tb = new TextBox();
                        tb.Location = new System.Drawing.Point(50 + (i * 35), 50 + (j * 35));
                        tb.Size = new System.Drawing.Size(25, 25);
                        tb.Text = matrix[i, j];
                        this.Controls.Add(tb);
                    }
                }
            }
        }

        //public void display(string[,] matrix)
        //{
        //    // matrix is always square
        //    if (matrix.Length > 100)
        //    {
        //        throw new System.Exception("Exceeded maximum matrix size");
        //    }
        //    else
        //    {

        //        for (int i = 0; i < Math.Sqrt(matrix.Length); i++)
        //        {
        //            for (int j = 0; j < Math.Sqrt(matrix.Length); j++)
        //            {
        //                TextBox tb = new TextBox();
        //                tb.Location = new System.Drawing.Point(10 + (i * 20), 10 + (j * 20));
        //                tb.Size = new System.Drawing.Size(15, 15);
        //                this.Controls.Add(tb);
        //            }
        //        }
        //    }


        //}
    }
}
