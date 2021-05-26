using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Player
{
    public interface IPlayList
    {
        void AddTrack(string track);

        void RemoveTrack(string track);

        void AddTracks(string[] tracks);

        string NextTrack();

        
    }
}
