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
    public partial class MainPage : ContentPage
    {
        IMediaPlayer mediaPlayer = DependencyService.Get<IMediaPlayer>();

        public MainPage()
        {
            InitializeComponent();
            
            IPlayList playlist = new PlayList();

            playlist.AddTracks(new ITrack[]{
                new Track("", "", "2 Best Enemies - Unity (Original Mix).mp3"),
                new Track("", "", "A Single Day - Approaching Nirvana.mp3"),
                new Track("", "", "A-Lusion - Marked For Life.mp3"),
                new Track("", "", "Acti & Darook MC - Kick My Brain.mp3"),
                new Track("", "", "Activator - One I Love.mp3"),
                new Track("", "", "Activator - Supersonic Bass.mp3"),
                new Track("", "", "Alpha2 & Wildstylez - Atrocious (Original Mix).mp3"),
                new Track("", "", "Alphaverb - Feel Good (Gentalica Remix).mp3"),
                new Track("", "", "Alphaverb - Rockin da Rework (Extended Mix).mp3"),
                new Track("", "", "Alphaverb - The Otherside  (Extended Album Mix).mp3"),
                new Track("", "", "Alphaverb - Thunderstyle (Remastered Club Mix).mp3"),
                new Track("", "", "Ambassador Inc - Rock the Dancefloor.mp3"),
                new Track("", "", "Ambassador Inc - Silence.mp3"),
                new Track("", "", "Ambassador Inc - The Hardstyle Nation.mp3"),
                new Track("", "", "Anderson T  - Cause & Effect (Original Mix).mp3"),
                new Track("", "", "B-Twinz - Rebellion.mp3"),
                new Track("", "", "Brian NRG - Real Street Shit (Original Mix).mp3"),
                new Track("", "", "Brooklyn Bounce - Club Bizarre (Headhunterz & Noisecontrollers Remix).mp3"),
                new Track("", "", "Catatonic Overload  - Heavyweight.mp3"),
                new Track("", "", "Catatonic Overload  - Paralyzed.mp3")
            });

            mediaPlayer.SelectPlayList(playlist);

                //Text_Label.Text = mediaPlayer.FileLocation;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            mediaPlayer.PlayPausePlayback();
        }

        private void SkipTrack(object sender, EventArgs e)
        {
            mediaPlayer.SkipTrack();
        }
    }
}
