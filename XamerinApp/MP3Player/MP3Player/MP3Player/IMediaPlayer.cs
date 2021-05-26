using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Player
{
    public interface IMediaPlayer
    {
        string FileLocation { get; }

        void SelectTrack(string fileName);

        void PlayPauseAudioFile();

        void SelectPlayList(IPlayList playList);

        void SkipTrack();
    }
}
