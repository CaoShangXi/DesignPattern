using DesignPattern.Bridge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPattern.UnitTests
{
    /// <summary>
    /// 桥接模式测试
    /// </summary>
    [TestClass]
    public class BridgePatternTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Shape redCircle = new Circle(100, 100, 10, new RedCircle());
            Shape greenCircle = new Circle(100, 100, 10, new GreenCircle());

            redCircle.Draw();
            greenCircle.Draw();
        }
    }
}
