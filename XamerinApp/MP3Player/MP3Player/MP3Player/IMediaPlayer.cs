using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Player
{
    public interface IMediaPlayer
    {
        /// <summary>
        /// File location of the current playing track
        /// </summary>
        string FileLocation { get; }

        /// <summary>
        /// select track by filename
        /// </summary>
        /// <param name="fileName">Filename to select</param>
        void SelectTrack(string fileName);

        /// <summary>
        /// PLay and pause the currently playing track
        /// </summary>
        void PlayPauseAudioFile();

        /// <summary>
        /// Select a playlist to play
        /// </summary>
        /// <param name="playList">Playlist object to handle tracks</param>
        void SelectPlayList(IPlayList playList);

        /// <summary>
        /// Skips the currently playing track and proceeds to the next track
        /// </summary>
        void SkipTrack();
    }
}
