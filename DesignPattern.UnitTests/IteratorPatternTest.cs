using DesignPattern.IteratorPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPattern.UnitTests
{
    [TestClass]
    public class IteratorPatternTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            NameRepository namesRepository = new NameRepository();

            for (IIterator iter = namesRepository.GetIterator(); iter.HasNext();)
            {
                string name = (string)iter.Next();
                Console.WriteLine("Name : " + name);
            }
        }
    }
}
