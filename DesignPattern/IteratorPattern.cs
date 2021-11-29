using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 迭代器模式
/// </summary>
namespace DesignPattern.IteratorPattern
{
    /// <summary>
    /// 迭代器模式
    /// </summary>
    public interface IIterator
    {
         bool HasNext();
         object Next();
    }

    /// <summary>
    /// 容器接口
    /// </summary>
    public interface IContainer
    {
        IIterator GetIterator();
    }

    public class NameRepository:IContainer
    {
   public static string[] names = { "Robert", "John", "Julie", "Lora" };

   public IIterator GetIterator()
    {
        return new NameIterator();
    }

    private class NameIterator:IIterator
    {
 
      int index;
      public bool HasNext()
    {
        if (index < names.Length)
        {
            return true;
        }
        return false;
    }
      public object Next()
    {
        if (this.HasNext())
        {
            return names[index++];
        }
        return null;
    }
}
}
}
