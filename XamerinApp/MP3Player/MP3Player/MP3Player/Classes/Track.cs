using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Player.Classes
{
    public class Track : TrackSimple, ITrack
    {
        public string TrackName { get; private set; }

        public string Artist { get; private set; }

        public Track(string trackName,string artist, string localfileName) : base(localfileName)
        {
            TrackName = trackName;

            Artist = artist;
        }

    }
}
