using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 拦截过滤器模式
/// </summary>
namespace DesignPattern.InterceptingFilterPattern
{
    /// <summary>
    /// 过滤器接口
    /// </summary>
    public interface IFilter
    {
        void Execute(string request);
    }

    /// <summary>
    /// 认证过滤器
    /// </summary>
    public class AuthenticationFilter : IFilter
    {
        public void Execute(string request)
        {
            Console.WriteLine("Authenticating request: " + request);
        }
    }
    /// <summary>
    /// Debug过滤器
    /// </summary>
    public class DebugFilter : IFilter
    {
        public void Execute(string request)
        {
            Console.WriteLine("request log: " + request);
        }
    }
    /// <summary>
    /// 请求处理程序
    /// </summary>
    public class Target
    {
        public void Execute(string request)
        {
            Console.WriteLine("Executing request: " + request);
        }
    }

    /// <summary>
    /// 过滤器链
    /// </summary>
    public class FilterChain
    {
        private List<IFilter> filters = new List<IFilter>();
        private Target target;

        public void AddFilter(IFilter filter)
        {
            filters.Add(filter);
        }

        public void Execute(string request)
        {
            foreach (IFilter filter in filters)
            {
                filter.Execute(request);
            }
            target.Execute(request);
        }

        public void SetTarget(Target target)
        {
            this.target = target;
        }
    }

    /// <summary>
    /// 过滤器管理器
    /// </summary>
    public class FilterManager
    {
        FilterChain filterChain;

        public FilterManager(Target target)
        {
            filterChain = new FilterChain();
            filterChain.SetTarget(target);
        }
        public void SetFilter(IFilter filter)
        {
            filterChain.AddFilter(filter);
        }

        public void FilterRequest(string request)
        {
            filterChain.Execute(request);
        }
    }

    /// <summary>
    /// 客户端
    /// </summary>
    public class Client
    {
        FilterManager filterManager;

        public void SetFilterManager(FilterManager filterManager)
        {
            this.filterManager = filterManager;
        }

        public void SendRequest(string request)
        {
            filterManager.FilterRequest(request);
        }
    }
}
