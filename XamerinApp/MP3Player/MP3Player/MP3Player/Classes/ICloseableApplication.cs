using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Player.Classes
{
    public interface ICloseableApplication
    {

        /// <summary>
        /// implements a specific method for closing the application.
        /// </summary>
        void CloseApplication();
    }
}
