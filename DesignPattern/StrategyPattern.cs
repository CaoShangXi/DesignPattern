using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 策略模式，Context类依不同的策略类调用不同的方法
/// </summary>
namespace DesignPattern.StrategyPattern
{
    /// <summary>
    /// 策略接口
    /// </summary>
    public interface IStrategy
    {
        int DoOperation(int num1, int num2);
    }
    /// <summary>
    /// 增加
    /// </summary>
    public class OperationAdd : IStrategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 + num2;
        }
    }
    /// <summary>
    /// 减去
    /// </summary>
    public class OperationSubtract : IStrategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 - num2;
        }
    }
    /// <summary>
    /// 倍增
    /// </summary>
    public class OperationMultiply : IStrategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 * num2;
        }
    }
    /// <summary>
    /// 上下文类
    /// </summary>
    public class Context
    {
        private IStrategy strategy;

        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int ExecuteStrategy(int num1, int num2)
        {
            return strategy.DoOperation(num1, num2);
        }
    }
}
