using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 状态模式
/// </summary>
namespace DesignPattern.StatePattern
{
    public interface IState
    {
        void DoAction(Context context);
    }

    public class StartState:IState
    {
   public void DoAction(Context context)
    {
        Console.WriteLine("Player is in start state");
        context.SetState(this);
    }

    public override string ToString()
    {
        return "Start State";
    }
}

    public class StopState:IState
    {


   public void DoAction(Context context)
    {
        Console.WriteLine("Player is in stop state");
        context.SetState(this);
    }

    public override string ToString()
    {
        return "Stop State";
    }
}

    public class Context
    {
        private IState state;

        public Context()
        {
            state = null;
        }

        public void SetState(IState state)
        {
            this.state = state;
        }

        public IState GetState()
        {
            return state;
        }
    }
}
