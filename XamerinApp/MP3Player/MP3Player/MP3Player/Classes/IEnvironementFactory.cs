using MP3Player.Classes.MediaPlayer;
using MP3Player.Classes.Tracks;

namespace MP3Player.Classes
{
    public interface IEnvironmentFactory
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
        /// <param name="playlistName">The PlaylistName name</param>
        /// <returns>playlist object with no tracks</returns>
        IPlayList CreateEmptyPlayList(string playlistName);

        /// <summary>
        /// Creats a track object with the name,artist and filename
        /// </summary>
        /// <param name="trackName">The track name</param>
        /// <param name="artist">artist</param>
        /// <param name="filename">Filename on the device</param>
        /// <returns>Track with the information</returns>
        ITrackSimple CreateTrack(string trackName,string artist,string filename);

        /// <summary>
        /// Creates i track simple based on a file only
        /// </summary>
        /// <param name="filePath">the local file path</param>
        /// <returns>a simple track only consisting of filepath</returns>
        ITrackSimple CreateTrack(string filePath);

        /// <summary>
        /// Creates a device specific file service using the public media Folder.
        /// </summary>
        /// <param name="paths">the path leading up to the location</param>
        /// <returns>A file service with the paths defined</returns>
        IFileService CreateFileServicePublicAccess(string path);


        /// <summary>
        /// Creates a full path to the storage location
        /// </summary>
        /// <param name="paths">The full defined path to the location</param>
        /// <returns>Fileservice setup to work in that location</returns>
        IFileService CreateFileServiceCustomPath(string[] paths);

        /// <summary>
        /// Gets the device specific closeable application
        /// </summary>
        /// <returns>Returns a specific implementation to close the application</returns>
        ICloseableApplication GetCloseableApplication();
    }
}
