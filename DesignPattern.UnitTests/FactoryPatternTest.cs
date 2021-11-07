using DesignPattern.FactoryPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPattern.UnitTests
{
    [TestClass]
    public class FactoryPatternTest
    {
        /// <summary>
        /// 测试工厂模式
        /// </summary>
        [TestMethod]
        public void TestMathod1()
        {
            ShapeFactory factory=new ShapeFactory();
            IShape circle=factory.GetShape("Circle");
            circle.Draw();
            IShape square = factory.GetShape("Square");
            square.Draw();
            IShape rectangle = factory.GetShape("Rectangle");
            rectangle.Draw();
        }
    }
}
