namespace MP3Player.Classes.MediaPlayer
{
    public interface IMediaPlayerSubject
    {
        /// <summary>
        /// Register an observer that requires updates from the Media player subject
        /// </summary>
        /// <param name="playerObserver">The observer to register</param>
        void RegisterObserver(IMediaPlayerObserver playerObserver);

        /// <summary>
        /// Remove the observer from the list
        /// </summary>
        void RemoveObserver();

        /// <summary>
        /// Responsible for triggering the the update on the obsververs
        /// </summary>
        void NotifyObserver();

    }
}
