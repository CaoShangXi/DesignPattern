using DesignPattern.CompositePattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPattern.UnitTests
{
    /// <summary>
    /// 组合模式
    /// </summary>
    [TestClass]
    public class CompositePatternTest
    {
        [TestMethod]
        public void TestMethod1()
        {//CEO
            Employee CEO = new Employee("John", "CEO", 30000);
            //销售部主管
            Employee headSales = new Employee("Robert", "Head Sales", 20000);
            //市场部主管
            Employee headMarketing = new Employee("Michel", "Head Marketing", 20000);
            //促销员
            Employee clerk1 = new Employee("Laura", "Marketing", 10000);
            Employee clerk2 = new Employee("Bob", "Marketing", 10000);
            //销售员
            Employee salesExecutive1 = new Employee("Richard", "Sales", 10000);
            Employee salesExecutive2 = new Employee("Rob", "Sales", 10000);

            CEO.Add(headSales);
            CEO.Add(headMarketing);

            headSales.Add(salesExecutive1);
            headSales.Add(salesExecutive2);

            headMarketing.Add(clerk1);
            headMarketing.Add(clerk2);

            //打印该组织的所有员工
            Console.WriteLine(CEO);
            foreach (Employee headEmployee in CEO.GetSubordinates())
            {
                Console.WriteLine(headEmployee);
                foreach (Employee employee in headEmployee.GetSubordinates())
                {
                    Console.WriteLine(employee);
                }
            }
        }
    }
}
