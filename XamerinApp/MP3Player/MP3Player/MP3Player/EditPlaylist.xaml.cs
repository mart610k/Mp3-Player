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
    public partial class EditPlaylist : ContentPage, IMessagePublisher
    {
        IEnvironmentFactory environmentFactory = DependencyService.Get<IEnvironmentFactory>();

        IPlayList playList;


        public ObservableCollection<ITrackSimple> TracksPosibleToBeAdded { get; private set; }

        public EditPlaylist(IPlayList iplayList)
        {
            playList = iplayList;
            TracksPosibleToBeAdded = new ObservableCollection<ITrackSimple>();
            
            InitializeComponent();

            PLaylistName.Text = playList.Name;

            GetAllTracks();
            GetPlayListTracks();
        }

        protected override void OnAppearing()
        {
            iListTracks.ItemsSource = playList.Playlist;
            iList.ItemsSource = TracksPosibleToBeAdded;

            base.OnAppearing();
        }

        private void AddTrackToPlaylist(object sender, EventArgs e)
        {

            if (sender is Button)
            {
                Button mi = (Button)sender;
                Console.WriteLine(mi.CommandParameter);
                if (mi.CommandParameter is ITrackSimple)
                {
                    playList.AddTrack((ITrackSimple)mi.CommandParameter);
                }
            }
        }
        private void RemoveTrackFromPlaylist(object sender, EventArgs e)
        {

            if (sender is Button)
            {
                Button mi = (Button)sender;
                Console.WriteLine(mi.CommandParameter);
                if (mi.CommandParameter is ITrackSimple)
                {
                    playList.RemoveTrack((ITrackSimple)mi.CommandParameter);
                }
            }
            iListTracks.ItemsSource = null;
            iListTracks.ItemsSource = playList.Playlist;
        }

        
        private void GetPlayListTracks()
        {
            
        }

        private void GetAllTracks()
        {
            IFileService fileService = environmentFactory.CreateFileServicePublicAccess("");

            string[] tracks = fileService.GetAllFilesWithExtension("mp3");

            

            for (int i = 0; i < tracks.Length; i++)
            {
                Console.WriteLine(tracks[i]);

                ITrackSimple trackSimple = environmentFactory.CreateTrack(fileService.GetLocalFilePath(tracks[i]));

                Console.WriteLine(trackSimple.LocalFileName);
                TracksPosibleToBeAdded.Add(trackSimple);

            }
        }
    }
}