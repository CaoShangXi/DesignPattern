using DesignPattern.CommandPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static DesignPattern.CommandPattern.Stock;

namespace DesignPattern.UnitTests
{
    [TestClass]
    public class CommandPattern
    {
        [TestMethod]
        public void TestMethod1()
        {
            Stock abcStock = new Stock();

            BuyStock buyStockOrder = new BuyStock(abcStock);
            SellStock sellStockOrder = new SellStock(abcStock);

            Broker broker = new Broker();
            broker.TakeOrder(buyStockOrder);
            broker.TakeOrder(sellStockOrder);

            broker.PlaceOrders();
        }
    }
}
