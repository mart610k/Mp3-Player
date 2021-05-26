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
        MediaPlayer player;
        public AssetFileDescriptor CurrentlyPlaying { get; private set; }

        IPlayList playlist;

        public string FileLocation { get; private set; }

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
            player.Stop();
            player.Reset();

            CurrentlyPlaying = Android.App.Application.Context.Assets.OpenFd(fileName.LocalFileName);

            player.SetDataSource(CurrentlyPlaying.FileDescriptor, CurrentlyPlaying.StartOffset, CurrentlyPlaying.Length);

            player.Prepare();
        }

        public void SelectPlayList(IPlayList playList)
        {
            playlist = playList;

            player.Stop();
            player.Reset();

            CurrentlyPlaying = Android.App.Application.Context.Assets.OpenFd(playlist.NextTrack().LocalFileName);

            player.SetDataSource(CurrentlyPlaying.FileDescriptor, CurrentlyPlaying.StartOffset, CurrentlyPlaying.Length);

            player.Prepare();
        }

        public void SkipTrack()
        {
            SelectTrack(playlist.NextTrack());

            player.Start();
        }

        

        public void PreviousTrack()
        {
            throw new System.NotImplementedException();
        }

        public void StopPlayback()
        {
            throw new System.NotImplementedException();
        }

        ITrack IMediaPlayer.CurrentlyPlaying()
        {
            throw new System.NotImplementedException();
        }
    }
}