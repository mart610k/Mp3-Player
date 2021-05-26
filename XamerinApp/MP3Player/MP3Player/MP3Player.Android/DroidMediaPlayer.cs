using Xamarin.Forms;
using MP3Player.Droid;
using Android.Media;
using Android.Content.Res;
using MP3Player.Classes;
using System;

[assembly: Dependency(typeof(DroidMediaPlayer))]

namespace MP3Player.Droid
{
    public class DroidMediaPlayer : IMediaPlayer
    {
        private MediaPlayer player;
        private IPlayList playlist;
        private IMediaPlayerObserver observer = null;

        public DroidMediaPlayer()
        {
            player = new MediaPlayer();
            playlist = new PlayList();
            player.Completion += On_Current_Track_Completion;
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
        /// Event for when currnet Track have finished playing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_Current_Track_Completion(object sender, EventArgs e)
        {
            SkipTrack();
            NotifyObserver();
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

        public void RegisterObserver(IMediaPlayerObserver playerObserver)
        {
            observer = playerObserver;
        }

        public void RemoveObserver()
        {
            observer = null;
        }

        public void NotifyObserver()
        {
            if(observer != null)
            {
                observer.Update();
            }
        }
    }
}