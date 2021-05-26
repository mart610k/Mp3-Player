using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Player.Classes
{
    public class PlayList : IPlayList
    {
        List<ITrack> playList = new List<ITrack>();
        int currentTrack = -1;


        public void AddTrack(ITrack track)
        {
            playList.Add(track);
        }

        public void AddTracks(ITrack[] tracks)
        {
            playList.AddRange(tracks);
        }

        public ITrack CurrentTrack()
        {
            return playList[currentTrack];
        }

        public ITrack NextTrack()
        {
            currentTrack += 1;
            if (currentTrack > playList.Count - 1)
            {
                currentTrack = 0;
            }

            return playList[currentTrack];
        }

        public ITrack PreviousTrack()
        {
            currentTrack -= 1;
            if (currentTrack < 0)
            {
                currentTrack = playList.Count - 1;
            }

            return playList[currentTrack];
        }

        public void RemoveTrack(ITrack track)
        {
            throw new NotImplementedException();
        }
    }
}
