using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.CommandPattern
{
    /// <summary>
    /// 订单接口
    /// </summary>
    public interface IOrder
    {
        void Execute();
    }

    /// <summary>
    /// 请求类Stock
    /// </summary>
    public class Stock
    {

        private string name = "ABC";
        private int quantity = 10;

        /// <summary>
        /// 购买
        /// </summary>
        public void Buy()
        {
            Console.WriteLine("Stock [ Name: " + name + ", Quantity: " + quantity + "bought");
        }
        /// <summary>
        /// 抛售
        /// </summary>
        public void Sell()
        {
            Console.WriteLine("Stock [ Name: " + name + ", Quantity: " + quantity + " ] sold");
        }

    }
        /// <summary>
        /// 命令实体类
        /// </summary>
        public class BuyStock : IOrder
        {
            private Stock abcStock;

            public BuyStock(Stock abcStock)
            {
                this.abcStock = abcStock;
            }

            public void Execute()
            {
                abcStock.Buy();
            }
        }
        /// <summary>
        /// 命令实体类
        /// </summary>
        public class SellStock : IOrder
        {
            private Stock abcStock;

            public SellStock(Stock abcStock)
            {
                this.abcStock = abcStock;
            }

            public void Execute()
            {
                abcStock.Sell();
            }
        }

        /// <summary>
        /// 命令调用类
        /// </summary>
        public class Broker
        {
            private List<IOrder> orderList = new List<IOrder>();

            public void TakeOrder(IOrder order)
            {
                orderList.Add(order);
            }

           /// <summary>
           /// 下订单
           /// </summary>
            public void PlaceOrders()
            {
                foreach (IOrder order in orderList)
                {
                    order.Execute();
                }
                orderList.Clear();
            }
        }
}
