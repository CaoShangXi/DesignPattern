using DesignPattern.ProxyPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPattern.UnitTests
{
    [TestClass]
    public class ProxyPatternTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IImage image = new ProxyImage("test_10mb.jpg");
            // 图像将从磁盘加载
            image.Display();
            Console.WriteLine("");
            // 图像不需要从磁盘加载
            image.Display();
        }
    }
}
