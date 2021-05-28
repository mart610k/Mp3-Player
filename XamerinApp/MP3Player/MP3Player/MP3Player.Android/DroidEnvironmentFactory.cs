using MP3Player.Classes;
using MP3Player.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidEnvironmentFactory))]

namespace MP3Player.Droid
{
    public class DroidEnvironmentFactory : CommonEnvironmentFactory
    {
        public DroidEnvironmentFactory()
        {

        }

        public override IFileService CreateFileServicePublicAccess(string[] paths)
        {
            return new DroidFileService(paths);
        }

        public override IMediaPlayer CreateMediaPlayer(IFileService fileService, IPlayList playList)
        {
            return new DroidMediaPlayer(playList, fileService);
        }
    }
}