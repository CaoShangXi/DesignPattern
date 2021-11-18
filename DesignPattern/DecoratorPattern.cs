using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 装饰器模式
/// </summary>
namespace DesignPattern.DecoratorPattern
{
    public interface IShape
    {
        void Draw();
    }

    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Shape: Rectangle");
        }
    }

    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Shape: Circle");
        }
    }

    /// <summary>
    /// 图形装饰器类
    /// </summary>
    public abstract class ShapeDecorator : IShape
    {
        protected IShape decoratedShape;
        public ShapeDecorator(IShape decoratedShape)
        {
            this.decoratedShape = decoratedShape;
        }
        public virtual void Draw()
        {
            decoratedShape.Draw();
        }
    }

    public class RedShapeDecorator : ShapeDecorator
    {
        public RedShapeDecorator(IShape decoratedShape) : base(decoratedShape)
        {

        }
        public override void Draw()
        {
            decoratedShape.Draw();
            SetRedBorder(decoratedShape);
        }
        private void SetRedBorder(IShape decoratedShape)
        {
            Console.WriteLine("Border Color: Red");
        }
    }
}
