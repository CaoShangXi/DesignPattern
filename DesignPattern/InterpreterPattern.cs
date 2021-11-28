using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.InterpreterPattern
{
    /// <summary>
    /// 表达式接口
    /// </summary>
    public interface IExpression
    {
        bool Interpret(string context);
    }

    /// <summary>
    /// 终端表达式
    /// </summary>
    public class TerminalExpression : IExpression
    {
        private string data;
        public TerminalExpression(string data)
        {
            this.data = data;
        }
        public bool Interpret(string context)
        {
            if (context.Contains(data))
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// Or表达式
    /// </summary>
    public class OrExpression : IExpression
    {
        private IExpression expr1 = null;
        private IExpression expr2 = null;
        public OrExpression(IExpression expr1, IExpression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }
        public bool Interpret(string context)
        {
            return expr1.Interpret(context) || expr2.Interpret(context);
        }
    }

    /// <summary>
    /// And表达式
    /// </summary>
    public class AndExpression : IExpression
    {
        private IExpression expr1 = null;
        private IExpression expr2 = null;
        public AndExpression(IExpression expr1, IExpression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }
        public bool Interpret(String context)
        {
            return expr1.Interpret(context) && expr2.Interpret(context);
        }
    }
}
