using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 外观模式
/// </summary>
namespace DesignPattern.FacadePattern
{
    public interface IShape
    {
        void Draw();
    }
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Rectangle:Draw()");
        }
    }
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Square:Draw()");
        }
    }
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Circle:Draw()");
        }
    }

    /// <summary>
    /// 形状制造者
    /// </summary>
    public class ShapeMaker
    {
        private IShape circle;
        private IShape rectangle;
        private IShape square;

        public ShapeMaker()
        {
            circle = new Circle();
            rectangle = new Rectangle();
            square = new Square();
        }

        public void DrawCircle()
        {
            circle.Draw();
        }
        public void DrawRectangle()
        {
            rectangle.Draw();
        }
        public void DrawSquare()
        {
            square.Draw();
        }
    }
}
