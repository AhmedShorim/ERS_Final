using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


    public class myButtonObject : Button
    {
        // Draw the new button. 
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen myPen = new Pen(Color.Black);
            // Draw the button in the form of a circle
            graphics.DrawEllipse(myPen, 0, 0, 100, 100);
            myPen.Dispose();
        }
    }