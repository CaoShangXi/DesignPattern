using DesignPattern.DecoratorPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 装饰器模式测试
/// </summary>
namespace DesignPattern.UnitTests
{
    [TestClass]
    public class DecoratorPatternTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IShape circle = new Circle();
            ShapeDecorator redCircle = new RedShapeDecorator(new Circle());
            ShapeDecorator redRectangle = new RedShapeDecorator(new Rectangle());
            Console.WriteLine("Circle with normal border");
            circle.Draw();

            Console.WriteLine("\nCircle of red border");
            redCircle.Draw();

            Console.WriteLine("\nRectangle of red border");
            redRectangle.Draw();
        }
    }
}
