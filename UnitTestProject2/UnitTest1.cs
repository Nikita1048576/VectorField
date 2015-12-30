using System;
using VectorFieldTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void test_VFMath_rotateVec_test1()
        {
            vec2 v = new vec2(1.0f, 0.0f);
            vec2 v2 = new vec2(0.0f, 1.0f);
            VFMath.rotateVec(v, VFMath.toRadians(90));
            Assert.AreEqual(v, v2, "v is: " + v.x.ToString() + " " + v.y.ToString());
        }
        [TestMethod]
        public void test_VFMath_rotateVec_test2()
        {
            vec2 v = new vec2(1.0f, 0.0f);
            vec2 v2 = new vec2(0.0f, -1.0f);
            VFMath.rotateVec(v, VFMath.toRadians(-90));
            Assert.AreEqual(v, v2, "v is: " + v.x.ToString() + " " + v.y.ToString());
        }
        [TestMethod, Timeout(10000)]
        public void test_VectorField_load_test()
        {
            VectorField field = new VectorField(50, 50, 10, 10, 80, 80);
            int count = 1000;
            for (int i = 0; i < count; ++i)
            {
                field.applyRelax();
            }
        }
        [TestMethod, Timeout(10000)]
        public void test_VectorField_stress_test()
        {
            VectorField field = new VectorField(50, 50, 10, 10, 80, 80);
            int count = 2000;
            for (int i = 0; i < count; ++i)
            {
                field.applyRelax();
            }
        }
    }
}
