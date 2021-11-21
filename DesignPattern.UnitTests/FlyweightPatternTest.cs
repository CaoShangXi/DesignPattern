using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DesignPattern.FlyweightPattern;

namespace DesignPattern.UnitTests
{
    [TestClass]
    public class FlyweightPatternTest
    {
        private static string[] colors = { "Red", "Green", "Blue", "White", "Black" };
        [TestMethod]
        public void TestMethod1()
        {
            for (int i = 0; i < 20; ++i)
            {
                Circle circle =
                   (Circle)ShapeFactory.GetCircle(getRandomColor());
                circle.SetX(GetRandomX());
                circle.SetY(GetRandomY());
                circle.SetRadius(100);
                circle.Draw();
            }
        }
        private static string getRandomColor()
        {
            return colors[(int)(new Random().Next(4))];
        }
        private static int GetRandomX()
        {
            return (int)(new Random().Next(4) * 100);
        }
        private static int GetRandomY()
        {
            return (int)(new Random().Next(4) * 100);
        }
    }
}
