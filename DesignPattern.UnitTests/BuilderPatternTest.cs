using DesignPattern.BuilderPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPattern.UnitTests
{
    [TestClass]
    public class BuilderPatternTest
    {
        /// <summary>
        /// 测试建造者模式
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            MealBuilder mealBuilder = new MealBuilder();

            Meal vegMeal = mealBuilder.PrepareVegMeal();
            Console.WriteLine("Veg Meal");
            vegMeal.ShowItems();
            Console.WriteLine("Total Cost: " + vegMeal.GetCost());

            Meal nonVegMeal = mealBuilder.PrepareNonVegMeal();
            Console.WriteLine("\n\nNon-Veg Meal");
            nonVegMeal.ShowItems();
            Console.WriteLine("Total Cost: " + nonVegMeal.GetCost());
        }
    }
}
