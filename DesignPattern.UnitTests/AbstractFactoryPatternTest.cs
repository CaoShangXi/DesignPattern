using DesignPattern.AbstractFactoryPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPattern.UnitTests
{
    [TestClass]
    public class AbstractFactoryPatternTest
    {
        /// <summary>
        /// 测试抽象工厂模式
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            //获取形状工厂
            AbstractFactory shapeFactory = FactoryProducer.GetFactory("Shape");

            //获取形状为 Circle 的对象
            IShape shape1 = shapeFactory.GetShape("CIRCLE");

            //调用 Circle 的 Draw 方法
            shape1.Draw();

            //获取形状为 Rectangle 的对象
            IShape shape2 = shapeFactory.GetShape("RECTANGLE");

            //调用 Rectangle 的 Draw 方法
            shape2.Draw();

            //获取形状为 Square 的对象
            IShape shape3 = shapeFactory.GetShape("SQUARE");

            //调用 Square 的 Draw 方法
            shape3.Draw();

            //获取颜色工厂
            AbstractFactory colorFactory = FactoryProducer.GetFactory("Color");

            //获取颜色为 Red 的对象
            IColor color1 = colorFactory.GetColor("RED");

            //调用 Red 的 Fill 方法
            color1.Fill();

            //获取颜色为 Green 的对象
            IColor color2 = colorFactory.GetColor("Green");

            //调用 Green 的 Fill 方法
            color2.Fill();

            //获取颜色为 Blue 的对象
            IColor color3 = colorFactory.GetColor("BLUE");

            //调用 Blue 的 Fill 方法
            color3.Fill();
        }
    }
}
