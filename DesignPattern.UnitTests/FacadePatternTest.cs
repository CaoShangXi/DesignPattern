using DesignPattern.FacadePattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPattern.UnitTests
{
    /// <summary>
    /// 外观模式测试
    /// </summary>
    [TestClass]
    public class FacadePatternTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ShapeMaker shapeMaker = new ShapeMaker();

            shapeMaker.DrawCircle();
            shapeMaker.DrawRectangle();
            shapeMaker.DrawSquare();
        }
    }
}
