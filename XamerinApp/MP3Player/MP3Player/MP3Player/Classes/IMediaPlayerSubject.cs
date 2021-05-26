using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Player.Classes
{
    public interface IMediaPlayerSubject
    {

        void RegisterObserver(IMediaPlayerObserver playerObserver);

        void RemoveObserver();

        void NotifyObserver();

    }
}
