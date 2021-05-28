namespace MP3Player.Classes
{
    public class TrackSimple : ITrackSimple
    {
        public string LocalFileName { get; protected set; }


        public TrackSimple(string localfileName)
        {
            LocalFileName = localfileName;
        }
    }
}
