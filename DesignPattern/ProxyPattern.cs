using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 代理模式
/// </summary>
namespace DesignPattern.ProxyPattern
{
    public interface IImage
    {
        void Display();
    }

    public class RealImage : IImage
    {
        private String fileName;
        public RealImage(String fileName)
        {
            this.fileName = fileName;
            LoadFromDisk(fileName);
        }
        public void Display()
        {
            Console.WriteLine("Displaying " + fileName);
        }

        private void LoadFromDisk(String fileName)
        {
            Console.WriteLine("Loading " + fileName);
        }
    }

    public class ProxyImage : IImage
    {
        private RealImage realImage;
        private string fileName;
        public ProxyImage(String fileName)
        {
            this.fileName = fileName;
        }
        public void Display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(fileName);
            }
            realImage.Display();
        }
    }
}
