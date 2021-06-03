using MP3Player.Classes;
using MP3Player.Classes.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MP3Player
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPlaylist : ContentPage
    {
        IEnvironmentFactory environmentFactory = DependencyService.Get<IEnvironmentFactory>();

        IPlayList playList;

        public EditPlaylist(IPlayList iplayList)
        {
            playList = iplayList;

            InitializeComponent();

            PLaylistName.Text = playList.Name;
        }
    }
}