using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Player.Classes
{
    public interface IPlayList
    {
        
        /// <summary>
        /// Adds a track into the playlist
        /// </summary>
        /// <param name="track">FileName of the track</param>
        void AddTrack(ITrack track);

        
        /// <summary>
        /// Removes a track from the playlist
        /// </summary>
        /// <param name="track">The track object to remove</param>
        void RemoveTrack(ITrack track);

        
        /// <summary>
        /// Adds multiple tracks to the playlist
        /// </summary>
        /// <param name="tracks"></param>
        void AddTracks(ITrack[] tracks);


        /// <summary>
        /// Selects the next track for playback
        /// </summary>
        /// <returns>The next track name to play</returns>
        ITrack NextTrack();

        
        /// <summary>
        /// Selects the previously played track
        /// </summary>
        /// <returns>The previous track which were playing</returns>
        ITrack PreviousTrack();


        /// <summary>
        /// Gets the currently selected track 
        /// </summary>
        /// <returns>The selected track</returns>
        ITrack CurrentTrack();
    }
}
