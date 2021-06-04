using System;
using System.Collections.Generic;

namespace MP3Player.Classes.Tracks
{
    public class PlayList : IPlayList
    {
        public List<ITrackSimple> Playlist { get; private set; }
        int currentTrack = -1;

        public string Name { get; private set; }

        public PlayList(string playListName)
        {
            Name = playListName;
            Playlist = new List<ITrackSimple>();
        }

        public void AddTrack(ITrackSimple track)
        {
            Playlist.Add(track);
        }

        public void AddTracks(ITrackSimple[] tracks)
        {
            Playlist.AddRange(tracks);
        }

        public ITrackSimple CurrentTrack()
        {
            return Playlist[currentTrack];
        }

        public ITrackSimple NextTrack()
        {
            currentTrack += 1;
            if (currentTrack > Playlist.Count - 1)
            {
                currentTrack = 0;
            }

            return Playlist[currentTrack];
        }

        public ITrackSimple PreviousTrack()
        {
            currentTrack -= 1;
            if (currentTrack < 0)
            {
                currentTrack = Playlist.Count - 1;
            }

            return Playlist[currentTrack];
        }

        public void RemoveTrack(ITrackSimple track)
        {
            Playlist.Remove(track);
        }
    }
}
