using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Player.Classes
{
    public interface ITrack
    {

        /// <summary>
        /// The track name
        /// </summary>
        string TrackName { get; }

        /// <summary>
        /// Artist of the track
        /// </summary>
        string Artist { get; }
    }
}
