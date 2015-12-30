using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorFieldTest
{
    class VFMath
    {
        public static vec2 getRandVec(double max)
        {
            return new vec2((float)(rand.NextDouble() * max - max * 0.5), (float)(rand.NextDouble() * max - max * 0.5));
        }
        public static void rotateVec(vec2 v, float angle)
        {
            float sinf = (float)Math.Sin(angle);
            float cosf = (float)Math.Cos(angle);
            float nx = v.x * cosf - v.y * sinf;
            float ny = v.y * cosf + v.x * sinf;
            v.x = nx;
            v.y = ny;
        }
        public static float toRadians(float angle)
        {
            return angle * (float)Math.PI / 180.0f;
        }
        public static void randRotate(vec2 v)
        {
            float angle = (float)rand.NextDouble() * RAND_ANGLE_RATE - RAND_ANGLE_RATE * 0.5f;
            rotateVec(v, angle);
        }
        private static Random rand = new Random();
        public static readonly float RAND_ANGLE_RATE = toRadians(40);
    }
}
