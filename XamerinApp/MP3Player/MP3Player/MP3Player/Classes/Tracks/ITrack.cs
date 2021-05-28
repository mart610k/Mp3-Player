namespace MP3Player.Classes.Tracks
{
    public interface ITrack : ITrackSimple
    {

        /// <summary>
        /// The track name
        /// </summary>
        string TrackName { get; }

        /// <summary>
        /// Artist of the track
        /// </summary>
        string Artist { get; }
    }
}
