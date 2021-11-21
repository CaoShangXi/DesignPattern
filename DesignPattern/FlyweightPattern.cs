using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FlyweightPattern
{
    public interface IShape
    {
        void Draw();
    }

    public class Circle:IShape
    {
   private string color;
    private int x;
    private int y;
    private int radius;

    public Circle(string color)
    {
        this.color = color;
    }

    public void SetX(int x)
    {
        this.x = x;
    }

    public void SetY(int y)
    {
        this.y = y;
    }

    public void SetRadius(int radius)
    {
        this.radius = radius;
    }

   public void Draw()
    {
        Console.WriteLine("Circle: Draw() [Color : " + color
           + ", x : " + x + ", y :" + y + ", radius :" + radius);
    }
}

    public class ShapeFactory
    {
        private static readonly Dictionary<string, IShape> circleMap = new Dictionary<string,IShape>();

        public static IShape GetCircle(string color)
        {
            Circle circle = circleMap.ContainsKey(color)?(Circle)circleMap[color]:null;

            if (circle == null)
            {
                circle = new Circle(color);
                circleMap.Add(color, circle);
                Console.WriteLine("Creating circle of color : " + color);
            }
            return circle;
        }
    }
}
