using Xamarin.Forms;
using MP3Player.Droid;
using Android.Media;
using MP3Player.Classes;
using System;
using MP3Player.Classes.MediaPlayer;
using MP3Player.Classes.Tracks;

[assembly: Dependency(typeof(DroidMediaPlayer))]

namespace MP3Player.Droid
{
    public class DroidMediaPlayer : IMediaPlayer
    {
        private MediaPlayer player;
        private IPlayList playlist;
        private IMediaPlayerObserver observer = null;
        private IFileService fileService = null;

        public DroidMediaPlayer(IPlayList playlist,IFileService fileService)
        {
            player = new MediaPlayer();
            this.playlist = playlist;
            this.fileService = fileService;
            player.Completion += On_Current_Track_Completion;

            fileService.CreateFolderLocationIfNotExist();
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

        public void SelectTrack(ITrackSimple track)
        {
            PrepareForPlayback(track);
        }

        /// <summary>
        /// Event for when current Track have finished playing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_Current_Track_Completion(object sender, EventArgs e)
        {
            SkipTrack();
        }

        /// <summary>
        /// Prepares the player for playback
        /// </summary>
        private void PrepareForPlayback(ITrackSimple track)
        {
            player.Stop();
            player.Reset();
            
            player.SetDataSource(fileService.GetFullFilePath(track.LocalFileName));

            player.Prepare();
            NotifyObserver();

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

        public ITrackSimple CurrentlyPlaying()
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