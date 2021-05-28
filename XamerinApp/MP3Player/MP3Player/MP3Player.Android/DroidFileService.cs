using MP3Player.Classes;
using System.IO;

namespace MP3Player.Droid
{
    public class DroidFileService : IFileService
    {
        private string basePath;


        public DroidFileService(string[] paths)
        {
            basePath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), Android.OS.Environment.DirectoryMusic, Path.Combine(paths));
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
    }
}