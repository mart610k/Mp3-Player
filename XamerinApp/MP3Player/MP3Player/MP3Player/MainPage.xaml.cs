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
        IMediaPlayer mediaPlayer = DependencyService.Get<IMediaPlayer>();

        IEnvironementFactory environementFactory = DependencyService.Get<IEnvironementFactory>();

        public MainPage()
        {
            InitializeComponent();
            
            IPlayList playlist = new PlayList();
            mediaPlayer.RegisterObserver(this);
            playlist.AddTracks(new ITrack[]{
                //new Track("facility-alarm-908","mixkit","mixkit-facility-alarm-908.wav"),
                new Track("Unity (Original Mix)", "2 Best Enemies", "2 Best Enemies - Unity (Original Mix).mp3"),
                //new Track("A Single Day", "Approaching Nirvana", "A Single Day - Approaching Nirvana.mp3"),
                new Track("Marked For Life", "A-Lusion", "A-Lusion - Marked For Life.mp3"),
                new Track("Kick My Brain", "Acti & Darook MC", "Acti & Darook MC - Kick My Brain.mp3"),
                new Track("One I Love", "Activator", "Activator - One I Love.mp3"),
                new Track("Supersonic Bass", "Activator", "Activator - Supersonic Bass.mp3"),
                new Track("Atrocious (Original Mix)", "Alpha2 & Wildstylez", "Alpha2 & Wildstylez - Atrocious (Original Mix).mp3"),
                new Track("Feel Good (Gentalica Remix)", "Alphaverb", "Alphaverb - Feel Good (Gentalica Remix).mp3"),
                new Track("Rockin da Rework (Extended Mix)", "Alphaverb", "Alphaverb - Rockin da Rework (Extended Mix).mp3"),
                new Track("The Otherside  (Extended Album Mix)", "Alphaverb", "Alphaverb - The Otherside  (Extended Album Mix).mp3"),
                new Track("Thunderstyle (Remastered Club Mix)", "Alphaverb", "Alphaverb - Thunderstyle (Remastered Club Mix).mp3"),
                new Track("Rock the Dancefloor", "Ambassador Inc", "Ambassador Inc - Rock the Dancefloor.mp3"),
                new Track("Silence", "Ambassador Inc", "Ambassador Inc - Silence.mp3"),
                new Track("The Hardstyle Nation", "Ambassador Inc", "Ambassador Inc - The Hardstyle Nation.mp3"),
                new Track("Cause & Effect (Original Mix)", "Anderson T", "Anderson T  - Cause & Effect (Original Mix).mp3"),
                new Track("Rebellion", "B-Twinz", "B-Twinz - Rebellion.mp3"),
                new Track("Real Street Shit (Original Mix)", "Brian NRG", "Brian NRG - Real Street Shit (Original Mix).mp3"),
                new Track("Club Bizarre (Headhunterz & Noisecontrollers Remix)", "Brooklyn Bounce", "Brooklyn Bounce - Club Bizarre (Headhunterz & Noisecontrollers Remix).mp3"),
                new Track("Heavyweight", "Catatonic Overload", "Catatonic Overload  - Heavyweight.mp3"),
                new Track("Paralyzed", "Catatonic Overload", "Catatonic Overload  - Paralyzed.mp3")
            });

            mediaPlayer.SelectPlayList(playlist);

                //Text_Label.Text = mediaPlayer.FileLocation;
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
