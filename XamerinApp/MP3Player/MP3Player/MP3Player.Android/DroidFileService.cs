using MP3Player.Classes;
using System.IO;
using MP3Player.Classes.Tracks;
using System;

namespace MP3Player.Droid
{
    public class DroidFileService : IFileService
    {
        private string basePath;

        /// <summary>
        /// Gets the public external folder of the android device which gives the location of the folder based on the location passed in
        /// </summary>
        /// <param name="path"></param>
        public DroidFileService(string path)
        {
            //basePath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), Android.OS.Environment.DirectoryMusic, path);
            Console.WriteLine("PATH-1: " + Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), Android.OS.Environment.DirectoryMusic, path));
            Console.WriteLine("PATH-2: " + Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMusic).ToString(),path));
            basePath = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMusic).ToString(),path);
        }

        /// <summary>
        /// Gets a fully defined path to the location of the folder
        /// </summary>
        /// <param name="paths">full path as defined.</param>
        public DroidFileService(string[] paths)
        {
            basePath = Path.Combine(paths);
        }

        public string GetFullFilePath(string localFilePath)
        {
            return Path.Combine(basePath, localFilePath);
        }

        public void CreateFolderLocationIfNotExist()
        {
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
                
        }

        public string[] GetAllFilesWithExtension(string fileExtension)
        {
            return Directory.GetFiles(basePath, fileExtension, SearchOption.AllDirectories);
        }

        public string GetFileExtension(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            return fileInfo.Extension;
        }

        public string GetFileName(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            return fileInfo.Extension;
        }

        public ITrack GetMP3MetadataFromFile(string filepath)
        {
            throw new System.NotImplementedException();
        }

        public string GetLocalFilePath(string fullfilePath)
        {
            return Path.GetRelativePath(basePath, fullfilePath);
        }
    }
}