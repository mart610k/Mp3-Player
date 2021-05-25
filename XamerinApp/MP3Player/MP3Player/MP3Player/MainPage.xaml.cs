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
            Text_Label.Text = mediaPlayer.FileLocation;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            mediaPlayer.PlayPauseAudioFile();
        }
    }
}
