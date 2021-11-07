using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 工厂模式
/// </summary>
namespace DesignPattern.FactoryPattern
{
    /// <summary>
    /// 形状接口
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// 画
        /// </summary>
        void Draw();
    }

    /// <summary>
    /// 圆型
    /// </summary>
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("画圆形！");
        }
    }

    /// <summary>
    /// 正方形
    /// </summary>
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("画正方型！");
        }
    }

    /// <summary>
    /// 长方形
    /// </summary>
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("画长方形！");
        }
    }

    /// <summary>
    /// 形状工厂
    /// </summary>
    public class ShapeFactory
    {
        /// <summary>
        /// 以形状类型获取对应实例
        /// </summary>
        /// <param name="shapeType">形状类型</param>
        /// <returns></returns>
        public IShape GetShape(string shapeType)
        {
            if (shapeType == null)
            {
                return null;
            }
            if (shapeType.Equals("CIRCLE", StringComparison.CurrentCultureIgnoreCase))
            {
                return new Circle();
            }
            if (shapeType.Equals("SQUARE", StringComparison.CurrentCultureIgnoreCase))
            {
                return new Square();
            }
            if (shapeType.Equals("RECTANGLE", StringComparison.CurrentCultureIgnoreCase))
            {
                return new Rectangle();
            }
            return null;
        }
    }
}
