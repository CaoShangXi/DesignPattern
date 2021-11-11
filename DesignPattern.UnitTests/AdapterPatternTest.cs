using DesignPattern.AdapterPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPattern.UnitTests
{
    /// <summary>
    /// 适配器模式
    /// </summary>
    [TestClass]
    public class AdapterPatternTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            AudioPlayer audioPlayer = new AudioPlayer();
            audioPlayer.Play("mp3", "beyond the horizon.mp3");
            audioPlayer.Play("mp4", "alone.mp4");
            audioPlayer.Play("vlc", "far far away.vlc");
            audioPlayer.Play("avi", "mind me.avi");
        }
    }
}
