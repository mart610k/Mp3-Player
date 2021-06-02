using MP3Player.Classes;
using MP3Player.Classes.Tracks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MP3Player
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistView : ContentPage
    {
        IEnvironmentFactory environmentFactory = DependencyService.Get<IEnvironmentFactory>();

        public ObservableCollection<IPlayList> PlayLists { 
            get {
                return playList;
                } 
        }
        private ObservableCollection<IPlayList> playList;
        public PlaylistView()
        {
            playList = new ObservableCollection<IPlayList>();
            InitializeComponent();

            playList.Add(environmentFactory.CreateEmptyPlayList());
            playList.Add(environmentFactory.CreateEmptyPlayList());
            playList.Add(environmentFactory.CreateEmptyPlayList());
            playList.Add(environmentFactory.CreateEmptyPlayList());
            playList.Add(environmentFactory.CreateEmptyPlayList());
        }

        protected override void OnAppearing()
        {

            iList.ItemsSource = PlayLists;
            foreach (var i in PlayLists)
            {
                .
            }

            base.OnAppearing();
        }

        private void GetTracks(object sender, EventArgs e)
        {
            string[] tracks = environmentFactory.CreateFileServicePublicAccess("").GetAllFilesWithExtension("mp3");

            foreach (string item in tracks)
            {
                Console.WriteLine(item);
            }
        }

        private async void NavigateToView(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}