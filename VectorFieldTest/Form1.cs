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
        StreamManager sm;
        public Form1()
        {
            InitializeComponent();
            dh = new DrawHandler(this);
            field = new VectorField(50, 50, 20, 20, 40, 40);
            sm = new StreamManager(field);
            sm.addStandartStreams();
            timer1.Interval = 16;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sm.applyStreams();
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
            sm.onoff(e.KeyCode);
        }
    }
}
