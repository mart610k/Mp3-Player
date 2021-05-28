namespace MP3Player.Classes.Tracks
{
    /// <summary>
    /// This is when only the file location is known
    /// </summary>
    public interface ITrackSimple
    {
        /// <summary>
        /// The local file name of the file location
        /// </summary>
        string LocalFileName { get; }
    }
}
