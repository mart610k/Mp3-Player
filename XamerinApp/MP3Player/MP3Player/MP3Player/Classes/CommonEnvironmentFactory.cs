﻿namespace MP3Player.Classes
{
    public abstract class CommonEnvironmentFactory : IEnvironmentFactory
    {
        public IPlayList CreateEmptyPlayList()
        {
            return new PlayList();
        }

        public abstract IFileService CreateFileServicePublicAccess(string[] paths);
        public abstract IMediaPlayer CreateMediaPlayer(IFileService fileService, IPlayList playList);

        public ITrack CreateTrack(string trackName, string artist, string filename)
        {
            return new Track(trackName, artist, filename);
        }
    }
}
