using MP3Player.Classes;
using MP3Player.Droid;
using Xamarin.Forms;
using MP3Player.Classes.MediaPlayer;
using MP3Player.Classes.Tracks;

[assembly: Dependency(typeof(DroidEnvironmentFactory))]

namespace MP3Player.Droid
{
    public class DroidEnvironmentFactory : CommonEnvironmentFactory
    {


        public DroidEnvironmentFactory()
        {

        }

        public override IFileService CreateFileServiceCustomPath(string[] paths)
        {
            return new DroidFileService(paths);
        }

        public override IFileService CreateFileServicePublicAccess(string path)
        {
            return new DroidFileService(path);
        }

        public override IMediaPlayer CreateMediaPlayer(IFileService fileService, IPlayList playList)
        {
            return new DroidMediaPlayer(playList, fileService);
        }

        public override ICloseableApplication GetCloseableApplication()
        {
            return new DroidCloseApplication();
        }
    }
}