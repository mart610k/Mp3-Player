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

            MessagingCenter.Subscribe<IMessagePublisher,IPlayList>(this, "SelectedPlayList", (sender,args) =>
            {
                SelectPlayList(args);
            }


            );
            PlayPauseButtonImgButton.Source = ImageResourceExtension.GetImageSource("MP3Player.Images.play_button.png");
            SkipButtonImgButton.Source = ImageResourceExtension.GetImageSource("MP3Player.Images.skip_button.png");
            PreviousButtonImgButton.Source = ImageResourceExtension.GetImageSource("MP3Player.Images.previous_button.png");
            //environmentFactory.GetPermissions();
            //if (!)
            //{

            //}
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

        private void SelectPlayList(IPlayList playList)
        {
            mediaPlayer.SelectPlayList(playList);
        }

        private void InitPlayer()
        {
            //IPlayList playList = environmentFactory.CreateEmptyPlayList("Test");
            //playList.AddTrack(environmentFactory.CreateTrack("Unity (Original Mix)", "2 Best Enemies", "Music/2 Best Enemies - Unity (Original Mix).mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("Marked For Life", "A-Lusion", "Music/A-Lusion - Marked For Life.mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("Kick My Brain", "Acti & Darook MC", "Music/Acti & Darook MC - Kick My Brain.mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("One I Love", "Activator", "Music/Activator - One I Love.mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("Supersonic Bass", "Activator", "Music/Activator - Supersonic Bass.mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("Atrocious (Original Mix)", "Alpha2 & Wildstylez", "Music/Alpha2 & Wildstylez - Atrocious (Original Mix).mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("Feel Good (Gentalica Remix)", "Alphaverb", "Music/Alphaverb - Feel Good (Gentalica Remix).mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("Rockin da Rework (Extended Mix)", "Alphaverb", "Music/Alphaverb - Rockin da Rework (Extended Mix).mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("The Otherside  (Extended Album Mix)", "Alphaverb", "Music/Alphaverb - The Otherside  (Extended Album Mix).mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("Thunderstyle (Remastered Club Mix)", "Alphaverb", "Music/Alphaverb - Thunderstyle (Remastered Club Mix).mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("Rock the Dancefloor", "Ambassador Inc", "Music/Ambassador Inc - Rock the Dancefloor.mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("Silence", "Ambassador Inc", "Music/Ambassador Inc - Silence.mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("The Hardstyle Nation", "Ambassador Inc", "Music/Ambassador Inc - The Hardstyle Nation.mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("Cause & Effect (Original Mix)", "Anderson T", "Music/Anderson T  - Cause & Effect (Original Mix).mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("Rebellion", "B-Twinz", "Music/B-Twinz - Rebellion.mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("Real Street Shit (Original Mix)", "Brian NRG", "Music/Brian NRG - Real Street Shit (Original Mix).mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("Club Bizarre (Headhunterz & Noisecontrollers Remix)", "Brooklyn Bounce", "Music/Brooklyn Bounce - Club Bizarre (Headhunterz & Noisecontrollers Remix).mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("Heavyweight", "Catatonic Overload", "Music/Catatonic Overload  - Heavyweight.mp3"));
            //playList.AddTrack(environmentFactory.CreateTrack("Paralyzed", "Catatonic Overload", "Music/Catatonic Overload  - Paralyzed.mp3"));

            mediaPlayer = environmentFactory.CreateMediaPlayer(environmentFactory.CreateFileServicePublicAccess(""), environmentFactory.CreateEmptyPlayList("Test"));
            mediaPlayer.RegisterObserver(this);
            //mediaPlayer.SelectPlayList(playList);

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
