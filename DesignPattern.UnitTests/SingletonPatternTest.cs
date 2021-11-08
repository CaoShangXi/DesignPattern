using DesignPattern.SingletonPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPattern.UnitTests
{
    [TestClass]
    public class SingletonPatternTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //不合法的构造函数
            //编译时错误：构造函数 SingleObject() 是不可见的
            //SingleObject obj = new SingleObject();

            //获取唯一可用的对象
            SingleObject obj = SingleObject.GetInstance();

            //显示消息
            obj.ShowMessage();
        }
    }
}
