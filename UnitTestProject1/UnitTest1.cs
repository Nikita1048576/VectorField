using System;
using VectorFieldTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void test_VFMath_toRadians_test1()
        {
            float angle = 90.0f;
            float angle_rad = VFMath.toRadians(angle);
            float angle_rad_exp = 1.570796f;
            Assert.AreEqual(angle_rad_exp, angle_rad, vec2.EPSILON, "angle is " + angle_rad.ToString());
        }
        [TestMethod]
        public void test_VFMath_toRadians_test2()
        {
            float angle = 180.0f;
            float angle_rad = VFMath.toRadians(angle);
            float angle_rad_exp = 3.141592f;
            Assert.AreEqual(angle_rad_exp, angle_rad, vec2.EPSILON, "angle is " + angle_rad.ToString());
        }
        [TestMethod, Timeout(10000)]
        public void test_VectorField_load_test()
        {
            VectorField field = new VectorField(50, 50, 10, 10, 80, 80);
            int count = 1000;
            for (int i=0; i<count; ++i)
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
