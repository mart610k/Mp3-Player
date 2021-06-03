using System;
using Xamarin.Forms;
using MP3Player.Classes;
using MP3Player.Classes.MediaPlayer;
using MP3Player.Classes.Tracks;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace MP3Player
{
    public partial class MainPage : ContentPage,IMediaPlayerObserver
    {
        IMediaPlayer mediaPlayer;
        IEnvironmentFactory environmentFactory = DependencyService.Get<IEnvironmentFactory>();


        public MainPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<IMessagePublisher>(this, "PermissionFileReadWrite", (sender) =>
              {
                  InitPlayer();

              }
            );
            MessagingCenter.Subscribe<IMessagePublisher>(this, "PermissionFileReadWriteFailed", (sender) =>
                {
                    environmentFactory.GetCloseableApplication().CloseApplication();
                
                }
            );

            MessagingCenter.Subscribe<IMessagePublisher,IPlayList>(this, "SelectedPlayList", (sender,iplaylist) =>
            {
                SelectPlayList(iplaylist);
            }


            );

            PlayPauseButtonImgButton.Source = ImageResourceExtension.GetImageSource("MP3Player.Images.play_button.png");
            SkipButtonImgButton.Source = ImageResourceExtension.GetImageSource("MP3Player.Images.skip_button.png");
            PreviousButtonImgButton.Source = ImageResourceExtension.GetImageSource("MP3Player.Images.previous_button.png");
        }

        /// <summary>
        /// Pause and start playback on the device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayPausePlayback(object sender, EventArgs e)
        {
            mediaPlayer.PlayPausePlayback();
        }

        /// <summary>
        /// Selects a given playlist for the music player to play
        /// </summary>
        /// <param name="playList">the playlist to select</param>
        private void SelectPlayList(IPlayList playList)
        {
            mediaPlayer.SelectPlayList(playList);
        }

        /// <summary>
        /// Initializes the media player for preperation to play tracks. triggered after the app have gotten read and write rights
        /// </summary>
        private void InitPlayer()
        {
            mediaPlayer = environmentFactory.CreateMediaPlayer(environmentFactory.CreateFileServicePublicAccess(""), environmentFactory.CreateEmptyPlayList("Test"));
            mediaPlayer.RegisterObserver(this);
        }

        /// <summary>
        /// Skips the current track and plays the next track
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkipTrack(object sender, EventArgs e)
        {
            mediaPlayer.SkipTrack();
        }

        /// <summary>
        /// Returns to the last track played.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousTrack(object sender, EventArgs e)
        {
            mediaPlayer.PreviousTrack();
        }

        /// <summary>
        /// Navigates to the page where playlists can be selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NavigateToPlayListView(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlaylistView());
        }
        
        public void Update()
        {
            ITrackSimple currentTrack = mediaPlayer.CurrentlyPlaying();
            LocalFileName.Text = currentTrack.LocalFileName;
            if (currentTrack is ITrack)
            {
                TrackName.Text = ((ITrack)currentTrack).TrackName;
                Artist.Text = ((ITrack)currentTrack).Artist;
            }
            else
            {
                TrackName.Text = "--No data--";
                Artist.Text = "--No data--";
            }

            //Insert code here to update GUI Interface with track information
        }
    }
}
