using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.BuilderPattern
{
    /// <summary>
    /// 食物条目接口
    /// </summary>
    public interface IItem
    {
        string Name();
        IPacking Packing();
        float Price();
    }

    /// <summary>
    /// 食物包装接口
    /// </summary>
    public interface IPacking
    {
        string Pack();
    }

    /// <summary>
    /// 包装纸
    /// </summary>
    public class Wrapper : IPacking
    {
        public string Pack()
        {
            return "Wrapper";
        }
    }

    /// <summary>
    /// 瓶子
    /// </summary>
    public class Bottle : IPacking
    {
        public string Pack()
        {
            return "Bottle";
        }
    }

    /// <summary>
    /// 汉堡
    /// </summary>
    public abstract class Burger : IItem
    {
        public abstract string Name();
        public IPacking Packing()
        {
            return new Wrapper();
        }
        public abstract float Price();
    }

    /// <summary>
    /// 冷饮
    /// </summary>
    public abstract class ColdDrink : IItem
    {
        public abstract string Name();
        public IPacking Packing()
        {
            return new Bottle();
        }
        public abstract float Price();
    }

    /// <summary>
    /// 素食汉堡
    /// </summary>
    public class VegBurger : Burger
    {

        public override float Price()
        {
            return 25.0f;
        }
        public override string Name()
        {
            return "Veg Burger";
        }
    }
    /// <summary>
    /// 鸡肉汉堡
    /// </summary>
    public class ChickenBurger : Burger
    {
        public override float Price()
        {
            return 50.5f;
        }
        public override string Name()
        {
            return "Chicken Burger";
        }
    }
    /// <summary>
    /// 可口可乐
    /// </summary>
    public class Coke : ColdDrink
    {
        public override float Price()
        {
            return 30.0f;
        }
        public override string Name()
        {
            return "Coke";
        }
    }
    /// <summary>
    /// 百事可乐
    /// </summary>
    public class Pepsi : ColdDrink
    {
        public override float Price()
        {
            return 35.0f;
        }
        public override string Name()
        {
            return "Pepsi";
        }
    }

    /// <summary>
    /// 套餐
    /// </summary>
    public class Meal
    {
        private List<IItem> items = new List<IItem>();

        public void AddItem(IItem item)
        {
            items.Add(item);
        }
        /// <summary>
        /// 获取费用
        /// </summary>
        /// <returns></returns>
        public float GetCost()
        {
            float cost = 0.0f;
            foreach (IItem item in items)
            {
                cost += item.Price();
            }
            return cost;
        }

        /// <summary>
        /// 显示项目
        /// </summary>
        public void ShowItems()
        {
            foreach (IItem item in items)
            {
                Console.WriteLine("Item : " + item.Name());
                Console.WriteLine(", Packing : " + item.Packing().Pack());
                Console.WriteLine(", Price : " + item.Price());
            }
        }
    }

   /// <summary>
   /// 套餐建立
   /// </summary>
    public class MealBuilder
    {
        /// <summary>
        /// 准备素食餐
        /// </summary>
        /// <returns></returns>
        public Meal PrepareVegMeal()
        {
            Meal meal = new Meal();
            meal.AddItem(new VegBurger());
            meal.AddItem(new Coke());
            return meal;
        }
        /// <summary>
        /// 准备非素食餐
        /// </summary>
        /// <returns></returns>
        public Meal PrepareNonVegMeal()
        {
            Meal meal = new Meal();
            meal.AddItem(new ChickenBurger());
            meal.AddItem(new Pepsi());
            return meal;
        }
    }
}

