using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 空对象模式
/// </summary>
namespace DesignPattern.NullObjectPattern
{
    public abstract class AbstractCustomer
    {
        protected string name;
        public abstract bool IsNil();
        public abstract string GetName();
    }

    public class RealCustomer : AbstractCustomer
    {
        public RealCustomer(string name)
        {
            this.name = name;
        }
        public override string GetName()
        {
            return name;
        }
        public override bool IsNil()
        {
            return false;
        }
    }

    public class NullCustomer : AbstractCustomer
    {
        public override string GetName()
        {
            return "Not Available in Customer Database";
        }
        public override bool IsNil()
        {
            return true;
        }
    }

    public class CustomerFactory
    {

        public static readonly string[] names = { "Rob", "Joe", "Julie" };

        public static AbstractCustomer GetCustomer(string name)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return new RealCustomer(name);
                }
            }
            return new NullCustomer();
        }
    }
}
