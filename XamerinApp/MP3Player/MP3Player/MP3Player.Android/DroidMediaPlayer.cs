using Xamarin.Forms;
using MP3Player.Droid;
using Android.Media;
using Android.Content.Res;
using MP3Player.Classes;

[assembly: Dependency(typeof(DroidMediaPlayer))]

namespace MP3Player.Droid
{
    public class DroidMediaPlayer : IMediaPlayer
    {
        private MediaPlayer player;
        private IPlayList playlist;

        public DroidMediaPlayer()
        {
            player = new MediaPlayer();
            playlist = new PlayList();
        }
        
        public void PlayPausePlayback()
        {
            if (!player.IsPlaying)
            {
                player.Start();
            }
            else
            {
                player.Pause();
            }
        }

        public void SelectTrack(ITrack fileName)
        {
            PrepareForPlayback(fileName);
        }

        /// <summary>
        /// Prepares the player for playback
        /// </summary>
        private void PrepareForPlayback(ITrack fileName)
        {

            player.Stop();
            player.Reset();

            AssetFileDescriptor currentlyPlaying = Android.App.Application.Context.Assets.OpenFd(fileName.LocalFileName);

            player.SetDataSource(currentlyPlaying.FileDescriptor, currentlyPlaying.StartOffset, currentlyPlaying.Length);

            player.Prepare();
        }

        public void SelectPlayList(IPlayList playList)
        {
            playlist = playList;

            PrepareForPlayback(playlist.NextTrack());
        }

        public void SkipTrack()
        {
            SelectTrack(playlist.NextTrack());

            player.Start();
        }

        public void PreviousTrack()
        {
            SelectTrack(playlist.PreviousTrack());
            player.Start();
        }

        public void StopPlayback()
        {
            player.Stop();
            player.Reset();
        }

        public ITrack CurrentlyPlaying()
        {
            return playlist.CurrentTrack();
        }
    }
}