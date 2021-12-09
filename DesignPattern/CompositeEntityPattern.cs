using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 组合实体模式
/// </summary>
namespace DesignPattern.CompositeEntityPattern
{
    /// <summary>
    /// 依赖对象1
    /// </summary>
    public class DependentObject1
    {

        private string data;

        public void SetData(string data)
        {
            this.data = data;
        }

        public string GetData()
        {
            return data;
        }
    }

    /// <summary>
    /// 依赖对象2
    /// </summary>
    public class DependentObject2
    {

        private string data;

        public void SetData(string data)
        {
            this.data = data;
        }

        public string GetData()
        {
            return data;
        }
    }

    /// <summary>
    /// 粗粒度对象
    /// </summary>
    public class CoarseGrainedObject
    {
        DependentObject1 do1 = new DependentObject1();
        DependentObject2 do2 = new DependentObject2();

        public void SetData(string data1, string data2)
        {
            do1.SetData(data1);
            do2.SetData(data2);
        }

        public string[] GetData()
        {
            return new string[] { do1.GetData(), do2.GetData() };
        }
    }

    /// <summary>
    /// 组合实体
    /// </summary>
    public class CompositeEntity
    {
        private CoarseGrainedObject cgo = new CoarseGrainedObject();

        public void SetData(string data1, string data2)
        {
            cgo.SetData(data1, data2);
        }

        public string[] GetData()
        {
            return cgo.GetData();
        }
    }

    /// <summary>
    /// 客户端
    /// </summary>
    public class Client
    {
        private CompositeEntity compositeEntity = new CompositeEntity();

        public void PrintData()
        {
            for (int i = 0; i < compositeEntity.GetData().Length; i++)
            {
                Console.WriteLine("Data: " + compositeEntity.GetData()[i]);
            }
        }

        public void SetData(string data1, string data2)
        {
            compositeEntity.SetData(data1, data2);
        }
    }
}
