using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 前端控制器模式
/// </summary>
namespace DesignPattern.FrontControllerPattern
{
    public class HomeView
    {
        public void Show()
        {
            Console.WriteLine("Displaying Home Page");
        }
    }

    public class StudentView
    {
        public void Show()
        {
            Console.WriteLine("Displaying Student Page");
        }
    }

    /// <summary>
    /// 调度器
    /// </summary>
    public class Dispatcher
    {
        private StudentView studentView;
        private HomeView homeView;
        public Dispatcher()
        {
            studentView = new StudentView();
            homeView = new HomeView();
        }

        public void Dispatch(string request)
        {
            if (request.Equals("STUDENT",StringComparison.CurrentCultureIgnoreCase))
            {
                studentView.Show();
            }
            else
            {
                homeView.Show();
            }
        }
    }

    /// <summary>
    /// 前端控制器
    /// </summary>
    public class FrontController
    {

        private Dispatcher dispatcher;

        public FrontController()
        {
            dispatcher = new Dispatcher();
        }

        private bool IsAuthenticUser()
        {
            Console.WriteLine("User is authenticated successfully.");
            return true;
        }

        private void TrackRequest(string request)
        {
            Console.WriteLine("Page requested: " + request);
        }

        public void DispatchRequest(string request)
        {
            //记录每一个请求
            TrackRequest(request);
            //对用户进行身份验证
            if (IsAuthenticUser())
            {
                dispatcher.Dispatch(request);
            }
        }
    }
}
