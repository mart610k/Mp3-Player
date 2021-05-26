using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Player
{
    public class PlayList : IPlayList
    {
        List<string> playList = new List<string>();
        int currentTrack = -1;


        public void AddTrack(string track)
        {
            playList.Add(track);
        }

        public void AddTracks(string[] tracks)
        {
            playList.AddRange(tracks);
        }

        public string NextTrack()
        {
            currentTrack += 1;
            if (currentTrack > playList.Count - 1)
            {
                currentTrack = 0;
            }

            return playList[currentTrack];
        }

        public void RemoveTrack(string track)
        {
            throw new NotImplementedException();
        }
    }
}
