using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 抽象工厂模式
/// </summary>
namespace DesignPattern.AbstractFactoryPattern
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
    public class ShapeFactory : AbstractFactory
    {
        public override IColor GetColor(string colorType)
        {
            throw new NotImplementedException();
        }

        public override IShape GetShape(string shapeType)
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

    /// <summary>
    /// 颜色
    /// </summary>
    public interface IColor
    {
        /// <summary>
        /// 填充
        /// </summary>
        void Fill();
    }

    /// <summary>
    /// 红色
    /// </summary>
    public class Red : IColor
    {
        public void Fill()
        {
            Console.WriteLine("填充红色！");
        }
    }

    /// <summary>
    /// 绿色
    /// </summary>
    public class Green : IColor
    {
        public void Fill()
        {
            Console.WriteLine("填充绿色！");
        }
    }

    /// <summary>
    /// 蓝色
    /// </summary>
    public class Blue : IColor
    {
        public void Fill()
        {
            Console.WriteLine("填充蓝色！");
        }
    }

    /// <summary>
    /// 颜色工厂
    /// </summary>
    public class ColorFactory:AbstractFactory
    {
        public override IColor GetColor(string colorType)
        {
            if (colorType == null)
            {
                return null;
            }
            if (colorType.Equals("RED", StringComparison.CurrentCultureIgnoreCase))
            {
                return new Red();
            }
            if (colorType.Equals("GREEN", StringComparison.CurrentCultureIgnoreCase))
            {
                return new Green();
            }
            if (colorType.Equals("BLUE", StringComparison.CurrentCultureIgnoreCase))
            {
                return new Blue();
            }
            return null;
        }

        public override IShape GetShape(string shapeType)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 抽象工厂
    /// </summary>
    public abstract class AbstractFactory
    {
        /// <summary>
        /// 以形状类型获取对应实例
        /// </summary>
        /// <param name="shapeType">形状类型</param>
        /// <returns></returns>
        public abstract IShape GetShape(string shapeType);

        /// <summary>
        /// 以颜色类型获取对应实例
        /// </summary>
        /// <param name="colorType">颜色类型</param>
        /// <returns></returns>
        public abstract IColor GetColor(string colorType);
    }

    /// <summary>
    /// 工厂创造器/生成器类
    /// </summary>
    public class FactoryProducer
    {
        /// <summary>
        /// 类型信息来获取实体类的对象
        /// </summary>
        /// <param name="factoryType">工厂类别</param>
        /// <returns></returns>
        public static AbstractFactory GetFactory(string factoryType)
        {
            if (factoryType.Equals("SHAPE",StringComparison.CurrentCultureIgnoreCase))
            {
                return new ShapeFactory();
            }
            if (factoryType.Equals("COLOR", StringComparison.CurrentCultureIgnoreCase))
            {
                return new ColorFactory();
            }
            return null;
        }
    }
}
