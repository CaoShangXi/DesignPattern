using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 备忘录模式
/// </summary>
namespace DesignPattern.MenmetoPattern
{
    /// <summary>
    /// 备忘录类
    /// </summary>
    public class Memento
    {
        private string state;

        public Memento(string state)
        {
            this.state = state;
        }

        public string GetState()
        {
            return state;
        }
    }

    public class Originator
    {
        private string state;

        public void SetState(string state)
        {
            this.state = state;
        }

        public string GetState()
        {
            return state;
        }

        public Memento SaveStateToMemento()
        {
            return new Memento(state);
        }

        public void GetStateFromMemento(Memento Memento)
        {
            state = Memento.GetState();
        }
    }

    public class CareTaker
    {
        private List<Memento> mementoList = new List<Memento>();

        public void Add(Memento state)
        {
            mementoList.Add(state);
        }

        public Memento Get(int index)
        {
            return mementoList[index];
        }
    }
}
