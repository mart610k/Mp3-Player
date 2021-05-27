using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Player.Classes
{
    public interface IEnvironementFactory
    {
       /// <summary>
       /// Creates a media player for the Device in use
       /// </summary>
       /// <param name="fileService">File service for the device</param>
       /// <param name="playList">playlist for the media player</param>
       /// <returns>Mediaplayer</returns>
        IMediaPlayer CreateMediaPlayer(IFileService fileService, IPlayList playList);

        /// <summary>
        /// Creates an empty playlist 
        /// </summary>
        /// <returns>playlist object with no tracks</returns>
        IPlayList CreateEmptyPlayList();

        /// <summary>
        /// Creats a track object with the name,artist and filename
        /// </summary>
        /// <param name="trackName">The track name</param>
        /// <param name="artist">artist</param>
        /// <param name="filename">Filename on the device</param>
        /// <returns>Track with the information</returns>
        ITrack CreateTrack(string trackName,string artist,string filename);

        /// <summary>
        /// Creates a device specific file service.
        /// </summary>
        /// <param name="paths">the path leading up to the location</param>
        /// <returns>A file service with the paths defined</returns>
        IFileService CreateFileService(string[] paths);
    }
}
