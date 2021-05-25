using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Player
{
    public interface IMediaPlayer
    {
        string FileLocation { get; }

        //string Artist { get; }

        void SelectTrack(string fileName);

        void PlayPauseAudioFile();
    }
}
