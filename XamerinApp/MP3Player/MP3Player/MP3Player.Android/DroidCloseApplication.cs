using Java.Lang;
using MP3Player.Classes;

namespace MP3Player.Droid
{
    class DroidCloseApplication : ICloseableApplication
    {
        public void CloseApplication()
        {
             JavaSystem.Exit(0);
        }
    }
}