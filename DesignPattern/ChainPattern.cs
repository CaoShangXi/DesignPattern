using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.ChainPattern
{
    public abstract class AbstractLogger
    {
        public static int INFO = 1;
        public static int DEBUG = 2;
        public static int ERROR = 3;
        protected int level;
        //责任链中的下一个元素
        protected AbstractLogger nextLogger;
        public void SetNextLogger(AbstractLogger nextLogger)
        {
            this.nextLogger = nextLogger;
        }
        public void LogMessage(int level, String message)
        {
            if (this.level <= level)
            {
                Write(message);
            }
            if (nextLogger != null)
            {
                nextLogger.LogMessage(level, message);
            }
        }
        abstract protected void Write(string message);
    }

    public class ConsoleLogger : AbstractLogger
    {
        public ConsoleLogger(int level)
        {
            this.level = level;
        }
        protected override void Write(string message)
        {
            Console.WriteLine("Standard Console::Logger: " + message);
        }
    }

    public class ErrorLogger : AbstractLogger
    {
        public ErrorLogger(int level)
        {
            this.level = level;
        }
        protected override void Write(String message)
        {
            Console.WriteLine("Error Console::Logger: " + message);
        }
    }

    public class FileLogger :AbstractLogger
    {
   public FileLogger(int level)
    {
        this.level = level;
    }
   protected override void Write(String message)
    {
        Console.WriteLine("File::Logger: " + message);
    }
}
}
