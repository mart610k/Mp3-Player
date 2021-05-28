namespace MP3Player.Classes
{
    public interface IMediaPlayer : IMediaPlayerSubject
    {
        /// <summary>
        /// select track by filename
        /// </summary>
        /// <param name="fileName">Filename to select</param>
        void SelectTrack(ITrackSimple fileName);

        /// <summary>
        /// PLay and pause the currently playing track
        /// </summary>
        void PlayPausePlayback();

        /// <summary>
        /// Select a playlist to play
        /// </summary>
        /// <param name="playList">Playlist object to handle tracks</param>
        void SelectPlayList(IPlayList playList);

        /// <summary>
        /// Skips the currently playing track and proceeds to the next track
        /// </summary>
        void SkipTrack();

        /// <summary>
        /// Go back the to previously playing track
        /// </summary>
        void PreviousTrack();


        /// <summary>
        /// Stops the currently playing track by returning to 0:00 of the track
        /// </summary>
        void StopPlayback();

        /// <summary>
        /// Gets the currently playing track
        /// </summary>
        /// <returns>The track which is currently playing</returns>
        ITrackSimple CurrentlyPlaying();

    }
}
