namespace MP3Player.Classes
{
    public interface IMediaPlayerSubject
    {

        void RegisterObserver(IMediaPlayerObserver playerObserver);

        void RemoveObserver();

        void NotifyObserver();

    }
}
