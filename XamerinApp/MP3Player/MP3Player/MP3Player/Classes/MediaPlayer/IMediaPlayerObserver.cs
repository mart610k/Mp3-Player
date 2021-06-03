namespace MP3Player.Classes.MediaPlayer
{
    public interface IMediaPlayerObserver
    {
        /// <summary>
        /// Responsible for updating the Music player with the information that a track have been changed
        /// Open for change to name it as "OnNewTrackPlaying".
        /// As there could be more observing areas that mainpage need to refer to.
        /// </summary>
        void Update();
    }
}
