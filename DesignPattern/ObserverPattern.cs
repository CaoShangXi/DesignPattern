using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 观察者模式，当被观察者状态发生改变时，消息通知到观察者
/// </summary>
namespace DesignPattern.ObserverPattern
{
    /// <summary>
    /// 被观察者
    /// </summary>
    public class Subject
    {

        private List<Observer> observers
           = new List<Observer>();
        private int state;

        public int GetState()
        {
            return state;
        }

        public void SetState(int state)
        {
            this.state = state;
            NotifyAllObservers();
        }

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void NotifyAllObservers()
        {
            foreach (Observer observer in observers)
            {
                observer.Update();
            }
        }

    }
    /// <summary>
    /// 观察者抽象类
    /// </summary>
    public abstract class Observer
    {
        protected Subject subject;
        public abstract void Update();
    }

    /// <summary>
    /// 观察者实体类
    /// </summary>
    public class BinaryObserver : Observer
    {
        public BinaryObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }
        public override void Update()
        {
            Console.WriteLine("Binary String: "
            + Convert.ToString(subject.GetState(), 2));
        }
    }

    /// <summary>
    /// 观察者实体类
    /// </summary>
    public class OctalObserver : Observer
    {
        public OctalObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }
        public override void Update()
        {
            Console.WriteLine("Octal String: "
            + Convert.ToString(subject.GetState(), 8));
        }
    }

    /// <summary>
    /// 观察者实体类
    /// </summary>
    public class HexaObserver : Observer
    {
        public HexaObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }
        public override void Update()
        {
            Console.WriteLine("Hexa String: "
            + Convert.ToString(subject.GetState(), 16));
        }
    }
}
