using DesignPattern.MediatorPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPattern.UnitTests
{
    [TestClass]
    public class MediatorPatternTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            User robert = new User("Robert");
            User john = new User("John");

            robert.SendMessage("Hi! John!");
            john.SendMessage("Hello! Robert!");
        }
    }
}
