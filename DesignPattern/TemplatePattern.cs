using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.TemplatePattern
{
    public abstract class Game
    {
        public abstract void Initialize();
        public abstract void StartPlay();
        public abstract void EndPlay();

        //模板
        public void Play()
        {

            //初始化游戏
            Initialize();

            //开始游戏
            StartPlay();

            //结束游戏
            EndPlay();
        }
    }

    /// <summary>
    /// 板球游戏
    /// </summary>
    public class Cricket : Game
    {

        public override void EndPlay()
        {
            Console.WriteLine("Cricket Game Finished!");
        }

        public override void Initialize()
        {
            Console.WriteLine("Cricket Game Initialized! Start playing.");
        }

        public override void StartPlay()
        {
            Console.WriteLine("Cricket Game Started. Enjoy the game!");
        }
    }

    /// <summary>
    /// 足球游戏
    /// </summary>
    public class Football : Game
    {

        public override void EndPlay()
        {
            Console.WriteLine("Football Game Finished!");
        }

        public override void Initialize()
        {
            Console.WriteLine("Football Game Initialized! Start playing.");
        }

        public override void StartPlay()
        {
            Console.WriteLine("Football Game Started. Enjoy the game!");
        }
    }
}
