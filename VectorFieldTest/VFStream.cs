using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorFieldTest
{
    class VFStream
    {
        public VFStream(int[][] cells, VectorField field, vec2 force)
        {
            mCells = cells;
            mField = field;
            mForce = new vec2(force);
            mIsOn = false;
        }
        public void activate()
        {
            mIsOn = true;
        }
        public void deactivate()
        {
            mIsOn = true;
        }
        public void onoff()
        {
            mIsOn = !mIsOn;
        }
        public void run()
        {
            if (mIsOn)
            {
                for (int i=0; i<mCells.Length; ++i)
                {
                    mField.applyForce(mCells[i][0], mCells[i][1], mForce);
                }
            }
        }
        public void setForce(vec2 force)
        {
            mForce = new vec2(force);
        }
        private VectorField mField;
        private int[][] mCells;
        private bool mIsOn;
        private vec2 mForce;
    }
}
