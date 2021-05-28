using MP3Player.Classes.MediaPlayer;
using MP3Player.Classes.Tracks;

namespace MP3Player.Classes
{
    public abstract class CommonEnvironmentFactory : IEnvironmentFactory
    {
        public IPlayList CreateEmptyPlayList()
        {
            return new PlayList();
        }

        public abstract IFileService CreateFileServicePublicAccess(string[] paths);
        public abstract IMediaPlayer CreateMediaPlayer(IFileService fileService, IPlayList playList);

        public ITrackSimple CreateTrack(string trackName, string artist, string filename)
        {
            return new Track(trackName, artist, filename);
        }

        public ITrackSimple CreateTrack(string filePath)
        {
            return new TrackSimple(filePath);
        }
    }
}
