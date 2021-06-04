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
        /// <summary>
        /// Responsible for creating Device specific objects and references
        /// </summary>
        IEnvironmentFactory environmentFactory = DependencyService.Get<IEnvironmentFactory>();

        /// <summary>
        /// Currently selected playlist to be chosen for the music player
        /// </summary>
        IPlayList selectedPLaylist = null;


        public ObservableCollection<IPlayList> PlayList { get; private set; }
        public PlaylistView()
        {
            PlayList = new ObservableCollection<IPlayList>();
            InitializeComponent();

            //Create a working playlist before setting the data
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

            //Generate static and temporary playlists for testing
            PlayList.Add(environmentFactory.CreateEmptyPlayList("First"));
            PlayList.Add(environmentFactory.CreateEmptyPlayList("Second"));
            PlayList.Add(environmentFactory.CreateEmptyPlayList("Third"));
            PlayList.Add(environmentFactory.CreateEmptyPlayList("Forth"));
            PlayList.Add(environmentFactory.CreateEmptyPlayList("Fifth"));
        }

        /// <summary>
        /// Prepares page before view is to be set up
        /// </summary>
        protected override void OnAppearing()
        {
            iList.ItemsSource = PlayList;

            base.OnAppearing();
        }

        /// <summary>
        /// Navigates to the Page where editing a playlist is possible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void EditPlayList(object sender, EventArgs e)
        {
            if (sender is MenuItem)
            {
                MenuItem mi = (MenuItem)sender;
                Console.WriteLine(mi.CommandParameter);
                if (mi.CommandParameter is IPlayList)
                {
                    selectedPLaylist = (IPlayList)mi.CommandParameter;
                    await Navigation.PushAsync(new EditPlaylist(selectedPLaylist));
                }
            }
            
        }

        /// <summary>
        /// Triggers the selection and sends message back to Main page on which track is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SelectPlayList(object sender, EventArgs e)
        {
            if(selectedPLaylist != null)
            {
                MessagingCenter.Send<IMessagePublisher, IPlayList>(this, "SelectedPlayList", selectedPLaylist);
                await Navigation.PopToRootAsync();
            }
        }


        /// <summary>
        /// Deletes a playlist from the current view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Adds a new playlist to the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddNewPlayList(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Create Playlist", "Type playlist name","Create","Cancel","New Playlist");

            if(result != null)
            {
                PlayList.Add(environmentFactory.CreateEmptyPlayList(result));
            }
        }

        
        /// <summary>
        /// Fires as soon as a menu item are selected on the GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPlayListTap(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView)
            {
                ListView mi = (ListView)sender;
                if (mi.SelectedItem is IPlayList)
                {
                    SelectPlayListButton.IsEnabled = true;
                    selectedPLaylist = (IPlayList)mi.SelectedItem;
                }
            }
        }
    }
}