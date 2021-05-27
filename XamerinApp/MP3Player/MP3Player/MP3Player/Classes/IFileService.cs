using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Player.Classes
{
    public interface IFileService
    {
        /// <summary>
        /// Gets the device specific file path for the device in use.
        /// </summary>
        /// <param name="localFilePath">The file name</param>
        /// <returns>full path to the file</returns>
        string GetFullFilePath(string localFilePath);


        /// <summary>
        /// Creates the folder the object have been instasiated with
        /// </summary>
        void CreateFolderLocationIfNotExist();

    }
}
