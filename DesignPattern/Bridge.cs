using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 桥接模式
/// </summary>
namespace DesignPattern.Bridge
{
    public interface IDrawAPI
    {
        void DrawCircle(int radius, int x, int y);
    }

    /// <summary>
    /// 红色圆圈
    /// </summary>
    public class RedCircle : IDrawAPI
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine("Drawing Circle[ color: red, radius: "
               + radius + ", x: " + x + ", " + y + "]");
        }
    }

    /// <summary>
    /// 绿色圆圈
    /// </summary>
    public class GreenCircle : IDrawAPI
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine("Drawing Circle[ color: green, radius: "
               + radius + ", x: " + x + ", " + y + "]");
        }
    }

    /// <summary>
    /// 形状
    /// </summary>
    public abstract class Shape
    {
        protected IDrawAPI drawAPI;
        protected Shape(IDrawAPI drawAPI)
        {
            this.drawAPI = drawAPI;
        }
        public abstract void Draw();
    }

    /// <summary>
    /// 圆形
    /// </summary>
    public class Circle : Shape
    {
        private int x, y, radius;
        public Circle(int x, int y, int radius, IDrawAPI drawAPI) : base(drawAPI)//调用父类构造方法
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }
        public override void Draw()
        {
            drawAPI.DrawCircle(radius, x, y);
        }
    }
}
