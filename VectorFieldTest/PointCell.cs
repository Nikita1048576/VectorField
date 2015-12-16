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
        private static readonly float SPREAD_RATE = 0.3f;
        public static readonly double RANDOM_RATE = 10.0;
        public PointCell(float nx, float ny, float dx, float dy, int n, int m)
        {
            mPosition = new vec2(nx, ny);
            mVelocity = new vec2();

            if (m > 1)
            {
                mRelatedPoints[1] = new PointCell(this, null, dx, m - 1);
            }
            if (n > 1)
            {
                mRelatedPoints[0] = new PointCell(this, dx, dy, n - 1, m);
            }
        }
        public PointCell(PointCell parent, float dx, float dy, int n, int m)
        {
            mPosition = new vec2(parent.mPosition.x, parent.mPosition.y + dy);
            mVelocity = new vec2();
            mRelatedPoints[2] = parent;

            if (m > 1)
            {
                mRelatedPoints[1] = new PointCell(this, parent.mRelatedPoints[1], dx, m - 1);
            }
            if (n > 1)
            {
                mRelatedPoints[0] = new PointCell(this, dx, dy, n - 1, m);
            }
        }
        public PointCell(PointCell parentX, PointCell parentY, float dx, int m)
        {
            mPosition = new vec2(parentX.mPosition.x + dx, parentX.mPosition.y);
            mVelocity = new vec2();
            mRelatedPoints[2] = parentY;
            if (parentY!=null)
            {
                parentY.mRelatedPoints[0] = this;
            }
            mRelatedPoints[3] = parentX;

            if (m > 1)
            {
                if (parentY != null)
                {
                    mRelatedPoints[1] = new PointCell(this, parentY.mRelatedPoints[1], dx, m - 1);
                }
                else
                {
                    mRelatedPoints[1] = new PointCell(this, null, dx, m - 1);
                }
            }
        }
        public PointCell get(int i, int j)
        {
            if (i > 0)
            {
                if (mRelatedPoints[0] != null)
                {
                    return mRelatedPoints[0].get(i - 1, j);
                }
                return null;
            }
            if (j > 0)
            {
                if (mRelatedPoints[1] != null)
                {
                    return mRelatedPoints[1].get(i, j - 1);
                }
                return null;
            }
            return this;
        }
        public void applyForce(vec2 force)
        {
            mVelocity = mVelocity + force;
        }
        public int changeDirection(int direction)
        {
            if (direction == 0)
            {
                return 2;
            }
            return 0;
        }
        public void applyRelax(int direction)
        {
            mVelocity.damp();
            vec2 newForce = mVelocity * SPREAD_RATE + vec2.getRand(RANDOM_RATE / 2.0);
            if (!newForce.empty())
            {
                newForce.randRotate();
                mVelocity = mVelocity * (1.0f - SPREAD_RATE);
                float xRate = Math.Abs(newForce.x) / (Math.Abs(newForce.x) + Math.Abs(newForce.y));
                if (newForce.x > 0)
                {
                    if (mRelatedPoints[1] != null)
                    {
                        mRelatedPoints[1].mVelocity = mRelatedPoints[1].mVelocity + newForce * xRate;
                    }
                }
                else
                {
                    if (mRelatedPoints[3] != null)
                    {
                        mRelatedPoints[3].mVelocity = mRelatedPoints[3].mVelocity + newForce * xRate;
                    }
                }

                if (newForce.y > 0)
                {
                    if (mRelatedPoints[0] != null)
                    {
                        mRelatedPoints[0].mVelocity = mRelatedPoints[0].mVelocity + newForce * (1.0f - xRate);
                    }
                }
                else
                {
                    if (mRelatedPoints[2] != null)
                    {
                        mRelatedPoints[2].mVelocity = mRelatedPoints[2].mVelocity + newForce * (1.0f - xRate);
                    }
                }
            }
            if (mRelatedPoints[direction] != null)
            {
                mRelatedPoints[direction].applyRelax(direction);
            }
            else
            {
                PointCell next = mRelatedPoints[1];
                if (next != null)
                {
                    next.applyRelax(changeDirection(direction));
                }
            }
        }
        public void draw(Graphics g, int direction)
        {
            Color col = Color.Black;
            for (int i = 0; i < 4; ++i )
            {
                if (mRelatedPoints[i] == null)
                {
                    if (col == Color.Yellow)
                    {
                        col = Color.Red;
                    }
                    else
                    {
                        col = Color.Yellow;
                    }
                }
            }
            g.DrawLine(new Pen(col), mPosition.x, mPosition.y, mPosition.x + mVelocity.x, mPosition.y + mVelocity.y);
            if (mRelatedPoints[direction] != null)
            {
                mRelatedPoints[direction].draw(g, direction);
            }
            else
            {
                PointCell next = mRelatedPoints[1];
                if (next != null)
                {
                    next.draw(g, changeDirection(direction));
                }
            }
        }
        private vec2 mPosition;
        private vec2 mVelocity;
        private PointCell[] mRelatedPoints = { null, null, null, null };
    }
}
