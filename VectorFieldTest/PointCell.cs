using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorFieldTest
{
    class PointCell
    {
        private static readonly float SPREAD_RATE = 0.5f;
        public static readonly double RANDOM_RATE = 5.0;
        public PointCell(float x, float y)
        {
            mPosition = new vec2(x, y);
            mVelocity = new vec2();
        }
        public static int getOppositeDirection(int direction)
        {
            int res = direction + 2;
            if (res>3)
            {
                res -= 4;
            }
            return res;
        }
        public static int getXDirection(vec2 v)
        {
            if (v.x > 0)
                return 1;
            return 3;
        }
        public static int getYDirection(vec2 v)
        {
            if (v.y > 0)
                return 0;
            return 2;
        }
        public void setNeighbors(int direction, PointCell neighbor)
        {
            mRelatedPoints[direction] = neighbor;
            int opposite = getOppositeDirection(direction);
            if (neighbor.mRelatedPoints[opposite] == null)
            {
                neighbor.setNeighbors(opposite, this);
            }
        }
        public void applyForce(vec2 force)
        {
            mVelocity = mVelocity + force;
        }
        public void applyRelax()
        {
            mVelocity = mVelocity + vec2.getRand(RANDOM_RATE);
            mVelocity.damp();
            vec2 newForce = mVelocity * SPREAD_RATE;
            if (!newForce.empty())
            {
                newForce.randRotate();
                mVelocity = mVelocity * (1.0f - SPREAD_RATE);
                float xRate = Math.Abs(newForce.x) / (Math.Abs(newForce.x) + Math.Abs(newForce.y));
                int xDir = getXDirection(newForce);
                int yDir = getYDirection(newForce);
                if (mRelatedPoints[xDir] != null)
                {
                    mRelatedPoints[xDir].mVelocity = mRelatedPoints[xDir].mVelocity + newForce * xRate;
                }
                if (mRelatedPoints[yDir] != null)
                {
                    mRelatedPoints[yDir].mVelocity = mRelatedPoints[yDir].mVelocity + newForce * (1.0f - xRate);
                }
            }
        }
        public void draw(Graphics g)
        {
            Color col = Color.Black;
            g.DrawLine(new Pen(col), mPosition.x, mPosition.y, mPosition.x + mVelocity.x, mPosition.y + mVelocity.y);
        }
        private vec2 mPosition;
        private vec2 mVelocity;
        private PointCell[] mRelatedPoints = { null, null, null, null };
    }
}
