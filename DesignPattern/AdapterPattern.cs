using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 适配器模式
/// </summary>
namespace DesignPattern.AdapterPattern
{
    /// <summary>
    /// 媒体播放器接口
    /// </summary>
    public interface IMediaPlayer
    {
        void Play(string audioType, string fileName);
    }

    /// <summary>
    /// 高级媒体播放器接口
    /// </summary>
    public interface IAdvancedMediaPlayer
    {
        void PlayVlc(string fileName);
        void PlayMp4(string fileName);
    }

    /// <summary>
    /// Vlc播放器
    /// </summary>
    public class VlcPlayer : IAdvancedMediaPlayer
    {
        public void PlayVlc(String fileName)
        {
            Console.WriteLine("Playing vlc file. Name: " + fileName);
        }
        public void PlayMp4(String fileName)
        {
            //什么也不做
        }
    }

    /// <summary>
    /// Mp4播放器
    /// </summary>
    public class Mp4Player : IAdvancedMediaPlayer
    {
        public void PlayVlc(String fileName)
        {
            //什么也不做
        }
        public void PlayMp4(String fileName)
        {
            Console.WriteLine("Playing mp4 file. Name: " + fileName);
        }
    }
    /// <summary>
    /// 媒体适配器
    /// </summary>
    public class MediaAdapter : IMediaPlayer
    {
        IAdvancedMediaPlayer advancedMusicPlayer;
        public MediaAdapter(String audioType)
        {
            if (audioType.Equals("vlc", StringComparison.CurrentCultureIgnoreCase))
            {
                advancedMusicPlayer = new VlcPlayer();
            }
            else if (audioType.Equals("mp4", StringComparison.CurrentCultureIgnoreCase))
            {
                advancedMusicPlayer = new Mp4Player();
            }
        }
        public void Play(String audioType, String fileName)
        {
            if (audioType.Equals("vlc", StringComparison.CurrentCultureIgnoreCase))
            {
                advancedMusicPlayer.PlayVlc(fileName);
            }
            else if (audioType.Equals("mp4", StringComparison.CurrentCultureIgnoreCase))
            {
                advancedMusicPlayer.PlayMp4(fileName);
            }
        }
    }

    /// <summary>
    /// 音频播放器
    /// </summary>
    public class AudioPlayer : IMediaPlayer
    {
        MediaAdapter mediaAdapter;
        public void Play(String audioType, String fileName)
        {

            //播放 mp3 音乐文件的内置支持
            if (audioType.Equals("mp3", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Playing mp3 file. Name: " + fileName);
            }
            //mediaAdapter 提供了播放其他文件格式的支持
            else if (audioType.Equals("vlc", StringComparison.CurrentCultureIgnoreCase)
               || audioType.Equals("mp4", StringComparison.CurrentCultureIgnoreCase))
            {
                mediaAdapter = new MediaAdapter(audioType);
                mediaAdapter.Play(audioType, fileName);
            }
            else
            {
                Console.WriteLine("Invalid media. " +
                   audioType + " format not supported");
            }
        }
    }
}
