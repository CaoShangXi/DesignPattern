using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 组合模式（Composite Pattern），又叫部分整体模式，
/// 是用于把一组相似的对象当作一个单一的对象。组合模式依据树形结构来组合对象，
/// 用来表示部分以及整体层次。
/// </summary>
namespace DesignPattern.CompositePattern
{
    public class Employee
    {
        private string name;
        private string dept;
        private int salary;
        private List<Employee> subordinates;

        //构造函数
        public Employee(string name, string dept, int sal)
        {
            this.name = name;
            this.dept = dept;
            this.salary = sal;
            subordinates = new List<Employee>();
        }

        public void Add(Employee e)
        {
            subordinates.Add(e);
        }

        public void Remove(Employee e)
        {
            subordinates.Remove(e);
        }

        public List<Employee> GetSubordinates()
        {
            return subordinates;
        }

        public override string ToString()
        {
            return ("Employee :[ Name : " + name
            + ", dept : " + dept + ", salary :"
            + salary + " ]");
        }
    }
}
