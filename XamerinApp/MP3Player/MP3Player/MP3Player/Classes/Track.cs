using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Player.Classes
{
    public class Track : ITrack
    {
        public string TrackName { get; private set; }

        public string Artist { get; private set; }

        public string LocalFileName { get; private set; }


        public Track(string trackName,string artist, string localfileName)
        {
            TrackName = trackName;

            Artist = artist;

            LocalFileName = localfileName;
        }

    }
}
