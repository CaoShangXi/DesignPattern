using DesignPattern.PrototypePattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPattern.UnitTests
{
    /// <summary>
    /// 原型模式测试
    /// </summary>
    [TestClass]
    public class PrototypePatternTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ShapeCache.LoadCache();

            Shape clonedShape = (Shape)ShapeCache.GetShape("1");
            Console.WriteLine("Shape : " + clonedShape.GetType());

            Shape clonedShape2 = (Shape)ShapeCache.GetShape("2");
            Console.WriteLine("Shape : " + clonedShape2.GetType());

            Shape clonedShape3 = (Shape)ShapeCache.GetShape("3");
            Console.WriteLine("Shape : " + clonedShape3.GetType());
        }
    }

    class Emp { 
    public string Name { get; set; }
     public   int Age { get; set; }
    }
}
