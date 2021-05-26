using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MP3Player
{
    public partial class MainPage : ContentPage
    {
        IMediaPlayer mediaPlayer = DependencyService.Get<IMediaPlayer>();

        public MainPage()
        {
            InitializeComponent();
            mediaPlayer.SelectTrack("A Single Day - Approaching Nirvana.mp3");
            IPlayList playlist = new PlayList();
            playlist.AddTracks(new string[]
            {
                "2 Best Enemies - Unity (Original Mix).mp3","A Single Day - Approaching Nirvana.mp3","A-Lusion - Marked For Life.mp3","Acti & Darook MC - Kick My Brain.mp3","Activator - One I Love.mp3","Activator - Supersonic Bass.mp3","Alpha2 & Wildstylez - Atrocious (Original Mix).mp3","Alphaverb - Feel Good (Gentalica Remix).mp3","Alphaverb - Rockin da Rework (Extended Mix).mp3","Alphaverb - The Otherside  (Extended Album Mix).mp3","Alphaverb - Thunderstyle (Remastered Club Mix).mp3","Ambassador Inc - Rock the Dancefloor.mp3","Ambassador Inc - Silence.mp3","Ambassador Inc - The Hardstyle Nation.mp3","Anderson T  - Cause & Effect (Original Mix).mp3","B-Twinz - Rebellion.mp3","Brian NRG - Real Street Shit (Original Mix).mp3","Brooklyn Bounce - Club Bizarre (Headhunterz & Noisecontrollers Remix).mp3","Catatonic Overload  - Heavyweight.mp3","Catatonic Overload  - Paralyzed.mp3"
            });

            mediaPlayer.SelectPlayList(playlist);

                //Text_Label.Text = mediaPlayer.FileLocation;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            mediaPlayer.PlayPauseAudioFile();
        }

        private void SkipTrack(object sender, EventArgs e)
        {
            mediaPlayer.SkipTrack();
        }
    }
}
