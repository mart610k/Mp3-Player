using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Player
{
    public interface IPlayList
    {
        /// <summary>
        /// Adds a track into the playlist
        /// </summary>
        /// <param name="track">FileName of the track</param>
        void AddTrack(string track);

        /// <summary>
        /// Removes a track from the playlist
        /// </summary>
        /// <param name="track">The track name to remove</param>
        void RemoveTrack(string track);

        /// <summary>
        /// Adds multiple tracks to the playlist
        /// </summary>
        /// <param name="tracks"></param>
        void AddTracks(string[] tracks);


        /// <summary>
        /// Selects the next track for playback
        /// </summary>
        /// <returns>The next track name to play</returns>
        string NextTrack();

        
    }
}
