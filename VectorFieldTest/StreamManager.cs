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
    class StreamManager
    {
        public StreamManager(VectorField vf)
        {
            mVF = vf;
        }
        public void setStream(Keys key, VFStream stream)
        {
            mStreams[key] = stream;
        }
        public void applyStreams()
        {
            foreach (KeyValuePair<Keys, VFStream> kvp in mStreams)
            {
                kvp.Value.run();
            }
        }
        public void activate(Keys key)
        {
            mStreams[key].activate();
        }
        public void deactivate(Keys key)
        {
            mStreams[key].deactivate();
        }
        public void onoff(Keys key)
        {
            mStreams[key].onoff();
        }
        public void addStandartStreams()
        {
            float strength = 100.0f;
            {
                int[][] cells = new int[][]
                {
                    new int[] {0, 18},
                    new int[] {0, 19},
                    new int[] {0, 20},
                    new int[] {0, 21},
                    new int[] {0, 22}
                };
                vec2 force = new vec2(strength, 0);
                VFStream stream = new VFStream(cells, mVF, force);
                setStream(Keys.Right, stream);
            }
            {
                int[][] cells = new int[][]
                {
                    new int[] {39, 18},
                    new int[] {39, 19},
                    new int[] {39, 20},
                    new int[] {39, 21},
                    new int[] {39, 22}
                };
                vec2 force = new vec2(-strength, 0);
                VFStream stream = new VFStream(cells, mVF, force);
                setStream(Keys.Left, stream);
            }
            {
                int[][] cells = new int[][]
                {
                    new int[] {18, 0},
                    new int[] {19, 0},
                    new int[] {20, 0},
                    new int[] {21, 0},
                    new int[] {22, 0}
                };
                vec2 force = new vec2(0, strength);
                VFStream stream = new VFStream(cells, mVF, force);
                setStream(Keys.Down, stream);
            }
            {
                int[][] cells = new int[][]
                {
                    new int[] {18, 39},
                    new int[] {19, 39},
                    new int[] {20, 39},
                    new int[] {21, 39},
                    new int[] {22, 39}
                };
                vec2 force = new vec2(0, -strength);
                VFStream stream = new VFStream(cells, mVF, force);
                setStream(Keys.Up, stream);
            }
        }
        private Dictionary<Keys, VFStream> mStreams = new Dictionary<Keys, VFStream>();
        private VectorField mVF;
    }
}
