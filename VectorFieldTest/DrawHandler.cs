using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorFieldTest
{
    class DrawHandler
    {
        private BufferedGraphicsContext context;
        private BufferedGraphics grafx;
        private Control canvas;
        public DrawHandler(Control c)
        {
            canvas = c;
            context = BufferedGraphicsManager.Current;
            context.MaximumBuffer = new Size(canvas.Width + 1, canvas.Height + 1);
            grafx = context.Allocate(canvas.CreateGraphics(),
                 new Rectangle(0, 0, canvas.Width, canvas.Height));
        }
        public void OnResize()
        {
            context.MaximumBuffer = new Size(canvas.Width + 1, canvas.Height + 1);
            if (grafx != null)
            {
                grafx.Dispose();
                grafx = null;
            }
            grafx = context.Allocate(canvas.CreateGraphics(),
                new Rectangle(0, 0, canvas.Width, canvas.Height));
            canvas.Refresh();
        }
        public Graphics getGraphics()
        {
            return grafx.Graphics;
        }
        public void Render()
        {
            grafx.Render(canvas.CreateGraphics());
            grafx.Graphics.FillRectangle(Brushes.White, 0, 0, canvas.Width, canvas.Height);
        }
    }
}
