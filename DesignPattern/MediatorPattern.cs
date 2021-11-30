using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 中介者模式
/// </summary>
namespace DesignPattern.MediatorPattern
{
    public class ChatRoom
    {
        public static void ShowMessage(User user, string message)
        {
            Console.WriteLine(DateTime.Now.ToString()
               + " [" + user.GetName() + "] : " + message);
        }
    }

    public class User
    {
        private string name;

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public User(string name)
        {
            this.name = name;
        }

        public void SendMessage(string message)
        {
            ChatRoom.ShowMessage(this, message);
        }
    }
}
