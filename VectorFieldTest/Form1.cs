using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorFieldTest
{
    public partial class Form1 : Form
    {
        DrawHandler dh;
        PointCell cell;
        public Form1()
        {
            InitializeComponent();
            dh = new DrawHandler(this);
            cell = new PointCell(50, 50, 20, 20, 40, 40);
            timer1.Interval = 16;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cell.applyRelax(0);
            Graphics graphics = dh.getGraphics();
            cell.draw(graphics, 0);
            dh.Render();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            float strength = 200.0f;
            if (e.KeyCode == Keys.Right)
            {
                PointCell newCell1 = cell.get(20, 0);
                PointCell newCell2 = cell.get(21, 0);
                PointCell newCell3 = cell.get(19, 0);
                PointCell newCell4 = cell.get(22, 0);
                PointCell newCell5 = cell.get(18, 0);
                newCell1.applyForce(new vec2(strength, 0));
                newCell2.applyForce(new vec2(strength, 0));
                newCell3.applyForce(new vec2(strength, 0));
                newCell4.applyForce(new vec2(strength, 0));
                newCell5.applyForce(new vec2(strength, 0));
            }
            if (e.KeyCode == Keys.Down)
            {
                PointCell newCell1 = cell.get(0, 20);
                PointCell newCell2 = cell.get(0, 21);
                PointCell newCell3 = cell.get(0, 19);
                PointCell newCell4 = cell.get(0, 22);
                PointCell newCell5 = cell.get(0, 18);
                newCell1.applyForce(new vec2(0, strength));
                newCell2.applyForce(new vec2(0, strength));
                newCell3.applyForce(new vec2(0, strength));
                newCell4.applyForce(new vec2(0, strength));
                newCell5.applyForce(new vec2(0, strength));
            }
        }
    }
}
