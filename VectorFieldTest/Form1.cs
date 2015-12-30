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
        VectorField field;
        public Form1()
        {
            InitializeComponent();
            dh = new DrawHandler(this);
            field = new VectorField(50, 50, 20, 20, 40, 40);
            timer1.Interval = 16;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            field.applyRelax();
            Graphics graphics = dh.getGraphics();
            field.draw(graphics);
            dh.Render();
        }
        private void applyForce(vec2 force, int[] cellsX, int[] cellsY)
        {
            for (int i=0; i<cellsX.Length; ++i)
            {
                field.applyForce(cellsX[i], cellsY[i], force);
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            float strength = 200.0f;
            if (e.KeyCode == Keys.Right)
            {
                vec2 force = new vec2(strength, 0);
                int[] cellsY = { 18, 19, 20, 21, 22 };
                int[] cellsX = { 0, 0, 0, 0, 0 };
                applyForce(force, cellsX, cellsY);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                {
                    vec2 force = new vec2(strength, 0);
                    int[] cellsY = { 18, 19, 20, 21, 22 };
                    int[] cellsX = { 0, 0, 0, 0, 0 };
                    applyForce(force, cellsX, cellsY);
                }
                {
                    vec2 force = new vec2(-strength, 0);
                    int[] cellsY = { 18, 19, 20, 21, 22 };
                    int[] cellsX = { 39, 39, 39, 39, 39 };
                    applyForce(force, cellsX, cellsY);
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                vec2 force = new vec2(-strength, 0);
                int[] cellsY = { 18, 19, 20, 21, 22 };
                int[] cellsX = { 39, 39, 39, 39, 39 };
                applyForce(force, cellsX, cellsY);
            }
            else if (e.KeyCode == Keys.Down)
            {
                vec2 force = new vec2(0, strength);
                int[] cellsX = { 18, 19, 20, 21, 22 };
                int[] cellsY = { 0, 0, 0, 0, 0 };
                applyForce(force, cellsX, cellsY);
            }
        }
    }
}
