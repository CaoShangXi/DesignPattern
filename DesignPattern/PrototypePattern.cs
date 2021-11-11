using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.PrototypePattern
{
    /// <summary>
    /// 形状
    /// </summary>
    public abstract class Shape : ICloneable
    {
        private string id;
        protected string type;

        public abstract void Draw();

        public new string GetType()
        {
            return type;
        }

        public string GetId()
        {
            return id;
        }

        public void SetId(string id)
        {
            this.id = id;
        }
        public object Clone()
        {
            object clone = null;
            try
            {
                clone = base.MemberwiseClone();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return clone;
        }
    }

    /// <summary>
    /// 长方形
    /// </summary>
    public class Rectangle : Shape
    {
        public Rectangle()
        {
            type = "Rectangle";
        }
        public override void Draw()
        {
            Console.WriteLine("Inside Rectangle::draw() method.");
        }
    }

    /// <summary>
    /// 正方形
    /// </summary>
    public class Square : Shape
    {
        public Square()
        {
            type = "Square";
        }
        public override void Draw()
        {
            Console.WriteLine("Inside Square::draw() method.");
        }
    }

    /// <summary>
    /// 圆形
    /// </summary>
    public class Circle : Shape
    {
        public Circle()
        {
            type = "Circle";
        }
        public override void Draw()
        {
            Console.WriteLine("Inside Circle::draw() method.");
        }
    }

    public class ShapeCache
    {

        private static Dictionary<string, Shape> shapeMap
           = new Dictionary<string,Shape>();

        public static Shape GetShape(string shapeId)
        {
            Shape cachedShape = shapeMap[shapeId];
            return (Shape)cachedShape.Clone();
        }

        // 对每种形状都运行数据库查询，并创建该形状
        // shapeMap.Add(shapeKey, shape);
        // 例如，我们要添加三种形状
        public static void LoadCache()
        {
            Circle circle = new Circle();
            circle.SetId("1");
            shapeMap.Add(circle.GetId(), circle);

            Square square = new Square();
            square.SetId("2");
            shapeMap.Add(square.GetId(), square);

            Rectangle rectangle = new Rectangle();
            rectangle.SetId("3");
            shapeMap.Add(rectangle.GetId(), rectangle);
        }
    }
}
