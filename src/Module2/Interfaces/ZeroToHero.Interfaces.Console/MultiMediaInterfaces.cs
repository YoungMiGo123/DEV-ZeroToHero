namespace ZeroToHero.Interfaces.Console
{
    using System;

    public class MultiMediaInterfaces
    {

        // Interface for audio playback
        public interface IAudioPlayer
        {
            void PlayAudio();
            void PauseAudio();
        }

        // Interface for video playback
        public interface IVideoPlayer
        {
            void PlayVideo();
            void PauseVideo();
        }

        // Class implementing both audio and video interfaces
        public class MultimediaDevice : IMultiMediaDevice
        {
            public void PlayAudio()
            {
                Console.WriteLine("Playing audio...");
            }

            public void PauseAudio()
            {
                Console.WriteLine("Pausing audio...");
            }

            public void PlayVideo()
            {
                Console.WriteLine("Playing video...");
            }

            public void PauseVideo()
            {
                Console.WriteLine("Pausing video...");
            }
        }
        public interface IMultiMediaDevice : IAudioPlayer, IVideoPlayer
        {
            // This interface is empty
        }
        public static void BuildMultiMediaExample()
        {
            // Create an instance of MultimediaDevice
            IVideoPlayer videoPlayer = new MultimediaDevice();

            videoPlayer.PlayVideo();
            videoPlayer.PauseVideo();

            IAudioPlayer audioPlayer = new MultimediaDevice();

            // Use the instance to play audio and video
            audioPlayer.PlayAudio();
            audioPlayer.PauseAudio();

            IMultiMediaDevice multiMediaDevice = new MultimediaDevice();

            multiMediaDevice.PlayAudio();
            multiMediaDevice.PauseAudio();
            multiMediaDevice.PlayVideo();
            multiMediaDevice.PauseVideo();

        }
    }
}
