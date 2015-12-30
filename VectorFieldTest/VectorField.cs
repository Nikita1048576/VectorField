using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace VectorFieldTest
{
    class VectorField
    {
        public VectorField(float nx, float ny, float dx, float dy, int n, int m)
        {
            N = n;
            M = m;
            mCell = new PointCell[n][];
            for (int i=0; i<N; ++i)
            {
                mCell[i] = new PointCell[m];
                for (int j = 0; j < M; ++j)
                {
                    mCell[i][j] = new PointCell(nx+j*dx, ny+i*dy);
                    if (i != 0)
                    {
                        mCell[i][j].setNeighbors(2, mCell[i - 1][j]);
                    }
                    if (j != 0)
                    {
                        mCell[i][j].setNeighbors(3, mCell[i][j - 1]);
                    }
                }
            }
        }
        public void applyRelax()
        {
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < M; ++j)
                {
                    mCell[i][j].applyRelax();
                }
            }
        }
        public void draw(Graphics g)
        {
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < M; ++j)
                {
                    mCell[i][j].draw(g);
                }
            }
        }
        public void applyForce(int x, int y, vec2 force)
        {
            if (x >= 0 && x < M && y >= 0 && y < N)
            {
                mCell[y][x].applyForce(force);
            }
        }
        private PointCell[][] mCell;
        private int N, M;
    }
}
