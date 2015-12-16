using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorFieldTest
{
    class vec2
    {
        public float x;
        public float y;
        public static readonly float DAMP_RATE = 0.999f;
        public static readonly float MAX_RATE = 300.0f;
        public static readonly float RAND_ANGLE_RATE = 40.0f * (float)Math.PI / 180.0f;
        private static Random rand = new Random();
        public vec2(float X, float Y)
        {
            x = X;
            y = Y;
        }
        public vec2()
        {
            x = 0;
            y = 0;
        }
        public vec2(vec2 v)
        {
            x = v.x;
            y = v.y;
        }
        public static vec2 operator +(vec2 a, vec2 b)
        {
            return new vec2(a.x + b.x, a.y + b.y);
        }
        public static vec2 operator -(vec2 a, vec2 b)
        {
            return new vec2(a.x - b.x, a.y - b.y);
        }
        public static vec2 operator *(float a, vec2 b)
        {
            return new vec2(a * b.x, a * b.y);
        }
        public static vec2 operator *(vec2 b, float a)
        {
            return new vec2(a * b.x, a * b.y);
        }
        public static vec2 operator /(vec2 b, float a)
        {
            return new vec2(b.x / a, b.y / a);
        }
        public static float operator *(vec2 a, vec2 b)
        {
            return a.x * b.x + a.y * b.y;
        }
        public static vec2 operator -(vec2 b)
        {
            return new vec2(-b.x, -b.y);
        }
        public float length()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }
        public vec2 normalize()
        {
            if (empty())
            {
                return new vec2();
            }
            float len = 1.0f / length();
            return new vec2(x * len, y * len);
        }
        public void damp()
        {
            if (x > MAX_RATE)
            {
                x = MAX_RATE;
            }
            if (x < -MAX_RATE)
            {
                x = -MAX_RATE;
            }
            if (y > MAX_RATE)
            {
                y = MAX_RATE;
            }
            if (y < -MAX_RATE)
            {
                y = -MAX_RATE;
            }
            x *= DAMP_RATE;
            y *= DAMP_RATE;
        }
        public static vec2 getRand(double max)
        {
            return new vec2((float)(rand.NextDouble() * max - max * 0.5), (float)(rand.NextDouble() * max - max * 0.5));
        }
        public void randRotate()
        {
            float a = (float)rand.NextDouble() * RAND_ANGLE_RATE - RAND_ANGLE_RATE * 0.5f;
            float sinf = (float)Math.Sin(a);
            float cosf = (float)Math.Cos(a);
            float nx = x * cosf - y * sinf;
            float ny = y * cosf + x * sinf;
            x = nx;
            y = ny;
        }
        public bool empty()
        {
            if (x == 0 && y == 0)
            {
                return true;
            }
            return false;
        }
    }
}
