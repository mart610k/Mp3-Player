using Xamarin.Forms;
using MP3Player.Droid;
using Android.Media;
using Android.Content.Res;

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
        
        public void PlayPauseAudioFile()
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

        public void SelectTrack(string fileName)
        {
            player.Stop();
            player.Reset();
            FileLocation = fileName;

            CurrentlyPlaying = Android.App.Application.Context.Assets.OpenFd(fileName);

            player.SetDataSource(CurrentlyPlaying.FileDescriptor, CurrentlyPlaying.StartOffset, CurrentlyPlaying.Length);

            player.Prepare();
        }

        public void SelectPlayList(IPlayList playList)
        {
            playlist = playList;

            player.Stop();
            player.Reset();

            CurrentlyPlaying = Android.App.Application.Context.Assets.OpenFd(playlist.NextTrack());

            player.SetDataSource(CurrentlyPlaying.FileDescriptor, CurrentlyPlaying.StartOffset, CurrentlyPlaying.Length);

            player.Prepare();
        }

        public void SkipTrack()
        {
            SelectTrack(playlist.NextTrack());

            player.Start();
        }
    }
}