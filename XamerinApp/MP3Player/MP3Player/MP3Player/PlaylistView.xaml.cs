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
    public partial class PlaylistView : ContentPage,IMessagePublisher
    {
        IEnvironmentFactory environmentFactory = DependencyService.Get<IEnvironmentFactory>();


        public ObservableCollection<IPlayList> PlayList { get; private set; }
        public PlaylistView()
        {
            PlayList = new ObservableCollection<IPlayList>();
            InitializeComponent();

            IPlayList playList = environmentFactory.CreateEmptyPlayList("Hardstyle");
            playList.AddTrack(environmentFactory.CreateTrack("Unity (Original Mix)", "2 Best Enemies", "Music/2 Best Enemies - Unity (Original Mix).mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("Marked For Life", "A-Lusion", "Music/A-Lusion - Marked For Life.mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("Kick My Brain", "Acti & Darook MC", "Music/Acti & Darook MC - Kick My Brain.mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("One I Love", "Activator", "Music/Activator - One I Love.mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("Supersonic Bass", "Activator", "Music/Activator - Supersonic Bass.mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("Atrocious (Original Mix)", "Alpha2 & Wildstylez", "Music/Alpha2 & Wildstylez - Atrocious (Original Mix).mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("Feel Good (Gentalica Remix)", "Alphaverb", "Music/Alphaverb - Feel Good (Gentalica Remix).mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("Rockin da Rework (Extended Mix)", "Alphaverb", "Music/Alphaverb - Rockin da Rework (Extended Mix).mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("The Otherside  (Extended Album Mix)", "Alphaverb", "Music/Alphaverb - The Otherside  (Extended Album Mix).mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("Thunderstyle (Remastered Club Mix)", "Alphaverb", "Music/Alphaverb - Thunderstyle (Remastered Club Mix).mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("Rock the Dancefloor", "Ambassador Inc", "Music/Ambassador Inc - Rock the Dancefloor.mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("Silence", "Ambassador Inc", "Music/Ambassador Inc - Silence.mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("The Hardstyle Nation", "Ambassador Inc", "Music/Ambassador Inc - The Hardstyle Nation.mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("Cause & Effect (Original Mix)", "Anderson T", "Music/Anderson T  - Cause & Effect (Original Mix).mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("Rebellion", "B-Twinz", "Music/B-Twinz - Rebellion.mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("Real Street Shit (Original Mix)", "Brian NRG", "Music/Brian NRG - Real Street Shit (Original Mix).mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("Club Bizarre (Headhunterz & Noisecontrollers Remix)", "Brooklyn Bounce", "Music/Brooklyn Bounce - Club Bizarre (Headhunterz & Noisecontrollers Remix).mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("Heavyweight", "Catatonic Overload", "Music/Catatonic Overload  - Heavyweight.mp3"));
            playList.AddTrack(environmentFactory.CreateTrack("Paralyzed", "Catatonic Overload", "Music/Catatonic Overload  - Paralyzed.mp3"));

            PlayList.Add(playList);
            PlayList.Add(environmentFactory.CreateEmptyPlayList("First"));
            PlayList.Add(environmentFactory.CreateEmptyPlayList("Second"));
            PlayList.Add(environmentFactory.CreateEmptyPlayList("Third"));
            PlayList.Add(environmentFactory.CreateEmptyPlayList("Forth"));
            PlayList.Add(environmentFactory.CreateEmptyPlayList("Fifth"));
        }

        protected override void OnAppearing()
        {

            iList.ItemsSource = PlayList;
            foreach (IPlayList i in PlayList)
            {
                Console.WriteLine("Playlist!");
            }

            base.OnAppearing();
        }

        private async void SelectPlayList(object sender, EventArgs e)
        {
            if (sender is MenuItem)
            {
                MenuItem mi = (MenuItem)sender;
                Console.WriteLine(mi.CommandParameter);
                if (mi.CommandParameter is IPlayList)
                {
                    MessagingCenter.Send<IMessagePublisher, IPlayList>(this, "SelectedPlayList", (IPlayList)mi.CommandParameter);
                    await Navigation.PopToRootAsync();

                }
            }
        }

        private async void OnDeleteDeletePlayList(object sender, EventArgs e)
        {
            if(sender is MenuItem)
            {
                MenuItem mi = (MenuItem)sender;
                Console.WriteLine(mi.CommandParameter);
                if(mi.CommandParameter is IPlayList)
                {
                    bool response = await DisplayAlert("Delete Context Action", "you are about to delete the playlist \"" + ((IPlayList)mi.CommandParameter).Name + "\"", "OK","Cancel");
                    if (response)
                    {
                        PlayList.Remove((IPlayList)mi.CommandParameter);
                    }
                }
            }

            

        }
        private void AddNewPlayList(object sender, EventArgs e)
        {
            PlayList.Add(environmentFactory.CreateEmptyPlayList("New"));
        }

        private void GetTracks(object sender, EventArgs e)
        {
            string[] tracks = environmentFactory.CreateFileServicePublicAccess("").GetAllFilesWithExtension("mp3");

            foreach (string item in tracks)
            {
                Console.WriteLine(item);
            }
        }

       

        private void MenuItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}