using MP3Player.Classes.Tracks;

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

        /// <summary>
        /// Gets all files in the given location filted by file extension
        /// </summary>
        /// <param name="fileExtension">the file extension to look for</param>
        /// <returns>all files with the extension</returns>
        string[] GetAllFilesWithExtension(string fileExtension);

        /// <summary>
        /// Gets the file extension from the file
        /// </summary>
        /// <param name="filePath">full filepath of the file</param>
        /// <returns>the extension the file have</returns>
        string GetFileExtension(string filePath);

        /// <summary>
        /// Gets the file name
        /// </summary>
        /// <param name="filePath">Full path to the file</param>
        /// <returns>the filename</returns>
        string GetFileName(string filePath);

        /// <summary>
        /// Attempts to get the MP3 file metadata from the MP3 file
        /// </summary>
        /// <param name="filepath">full file path</param>
        /// <returns>Track object with data from the file</returns>
        ITrack GetMP3MetadataFromFile(string filepath);

        /// <summary>
        /// Strips the file path that exists in the path leaving only the local filepath
        /// </summary>
        /// <param name="fullfilePath">the full file path to the file</param>
        /// <returns>the filepath that are defined by the fileservice</returns>
        string GetLocalFilePath(string fullfilePath);

    }
}
