using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 业务代表模式
/// </summary>
namespace DesignPattern.BusinessDelegatePattern
{
    /// <summary>
    /// 业务服务
    /// </summary>
    public interface IBusinessService
    {
        void DoProcessing();
    }

    public class EJBService : IBusinessService
    {
        public void DoProcessing()
        {
            Console.WriteLine("Processing task by invoking EJB Service");
        }
    }
    public class JMSService : IBusinessService
    {
        public void DoProcessing()
        {
            Console.WriteLine("Processing task by invoking JMS Service");
        }
    }

    /// <summary>
    /// 业务查询服务
    /// </summary>
    public class BusinessLookUp
    {
        public IBusinessService GetBusinessService(string serviceType)
        {
            if (serviceType.Equals("EJB"))
            {
                return new EJBService();
            }
            else
            {
                return new JMSService();
            }
        }
    }

    /// <summary>
    /// 业务代表
    /// </summary>
    public class BusinessDelegate
    {
        private BusinessLookUp lookupService = new BusinessLookUp();
        private IBusinessService businessService;
        private string serviceType;

        public void SetServiceType(string serviceType)
        {
            this.serviceType = serviceType;
        }

        public void DoTask()
        {
            businessService = lookupService.GetBusinessService(serviceType);
            businessService.DoProcessing();
        }
    }

    /// <summary>
    /// 客户端
    /// </summary>
    public class Client
    {

        BusinessDelegate businessService;

        public Client(BusinessDelegate businessService)
        {
            this.businessService = businessService;
        }

        public void DoTask()
        {
            businessService.DoTask();
        }
    }
}
