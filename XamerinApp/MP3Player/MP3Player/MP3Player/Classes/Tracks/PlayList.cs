using System;
using System.Collections.Generic;

namespace MP3Player.Classes.Tracks
{
    public class PlayList : IPlayList
    {
        List<ITrackSimple> playList = new List<ITrackSimple>();
        int currentTrack = -1;

        public string Name { get; private set; }

        public PlayList(string playListName)
        {
            Name = playListName;
        }

        public void AddTrack(ITrackSimple track)
        {
            playList.Add(track);
        }

        public void AddTracks(ITrackSimple[] tracks)
        {
            playList.AddRange(tracks);
        }

        public ITrackSimple CurrentTrack()
        {
            return playList[currentTrack];
        }

        public ITrackSimple NextTrack()
        {
            currentTrack += 1;
            if (currentTrack > playList.Count - 1)
            {
                currentTrack = 0;
            }

            return playList[currentTrack];
        }

        public ITrackSimple PreviousTrack()
        {
            currentTrack -= 1;
            if (currentTrack < 0)
            {
                currentTrack = playList.Count - 1;
            }

            return playList[currentTrack];
        }

        public void RemoveTrack(ITrackSimple track)
        {
            throw new NotImplementedException();
        }
    }
}
