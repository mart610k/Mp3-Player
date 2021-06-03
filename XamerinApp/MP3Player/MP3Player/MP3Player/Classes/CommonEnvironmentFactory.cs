using MP3Player.Classes.MediaPlayer;
using MP3Player.Classes.Tracks;

namespace MP3Player.Classes
{
    public abstract class CommonEnvironmentFactory : IEnvironmentFactory
    {
        public IPlayList CreateEmptyPlayList(string playlistName)
        {
            return new PlayList(playlistName);
        }

        public abstract IFileService CreateFileServiceCustomPath(string[] paths);
        public abstract IFileService CreateFileServicePublicAccess(string path);
        public abstract IMediaPlayer CreateMediaPlayer(IFileService fileService, IPlayList playList);

        public ITrackSimple CreateTrack(string trackName, string artist, string filename)
        {
            return new Track(trackName, artist, filename);
        }

        public ITrackSimple CreateTrack(string filePath)
        {
            return new TrackSimple(filePath);
        }

        public abstract ICloseableApplication GetCloseableApplication();
    }
}
