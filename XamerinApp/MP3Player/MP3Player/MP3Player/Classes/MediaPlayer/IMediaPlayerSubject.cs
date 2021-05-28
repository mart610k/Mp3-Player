namespace MP3Player.Classes.MediaPlayer
{
    public interface IMediaPlayerSubject
    {

        void RegisterObserver(IMediaPlayerObserver playerObserver);

        void RemoveObserver();

        void NotifyObserver();

    }
}
