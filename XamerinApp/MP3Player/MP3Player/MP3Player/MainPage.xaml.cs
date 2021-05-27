using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MP3Player.Classes;

namespace MP3Player
{
    public partial class MainPage : ContentPage,IMediaPlayerObserver
    {
        IMediaPlayer mediaPlayer;

        IEnvironmentFactory environementFactory = DependencyService.Get<IEnvironmentFactory>();

        public MainPage()
        {
            InitializeComponent();

            //IPlayList playList = environementFactory.CreateEmptyPlayList();
            //playList.AddTrack(environementFactory.CreateTrack("Unity (Original Mix)", "2 Best Enemies", "2 Best Enemies - Unity (Original Mix).mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("Marked For Life", "A-Lusion", "A-Lusion - Marked For Life.mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("Kick My Brain", "Acti & Darook MC", "Acti & Darook MC - Kick My Brain.mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("One I Love", "Activator", "Activator - One I Love.mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("Supersonic Bass", "Activator", "Activator - Supersonic Bass.mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("Atrocious (Original Mix)", "Alpha2 & Wildstylez", "Alpha2 & Wildstylez - Atrocious (Original Mix).mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("Feel Good (Gentalica Remix)", "Alphaverb", "Alphaverb - Feel Good (Gentalica Remix).mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("Rockin da Rework (Extended Mix)", "Alphaverb", "Alphaverb - Rockin da Rework (Extended Mix).mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("The Otherside  (Extended Album Mix)", "Alphaverb", "Alphaverb - The Otherside  (Extended Album Mix).mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("Thunderstyle (Remastered Club Mix)", "Alphaverb", "Alphaverb - Thunderstyle (Remastered Club Mix).mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("Rock the Dancefloor", "Ambassador Inc", "Ambassador Inc - Rock the Dancefloor.mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("Silence", "Ambassador Inc", "Ambassador Inc - Silence.mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("The Hardstyle Nation", "Ambassador Inc", "Ambassador Inc - The Hardstyle Nation.mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("Cause & Effect (Original Mix)", "Anderson T", "Anderson T  - Cause & Effect (Original Mix).mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("Rebellion", "B-Twinz", "B-Twinz - Rebellion.mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("Real Street Shit (Original Mix)", "Brian NRG", "Brian NRG - Real Street Shit (Original Mix).mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("Club Bizarre (Headhunterz & Noisecontrollers Remix)", "Brooklyn Bounce", "Brooklyn Bounce - Club Bizarre (Headhunterz & Noisecontrollers Remix).mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("Heavyweight", "Catatonic Overload", "Catatonic Overload  - Heavyweight.mp3"));
            //playList.AddTrack(environementFactory.CreateTrack("Paralyzed", "Catatonic Overload", "Catatonic Overload  - Paralyzed.mp3"));

            mediaPlayer  = environementFactory.CreateMediaPlayer(environementFactory.CreateFileServicePublicAccess(new string[] { "MP3Player2"}), environementFactory.CreateEmptyPlayList());
            mediaPlayer.RegisterObserver(this);
            //mediaPlayer.SelectPlayList(playList);
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

        public void Update()
        {
            ITrack currentTrack = mediaPlayer.CurrentlyPlaying();
            TrackName.Text = currentTrack.TrackName;
            Artist.Text = currentTrack.Artist;
            LocalFileName.Text = currentTrack.LocalFileName;
            //Insert code here to update GUI Interface with track information
        }
    }
}
