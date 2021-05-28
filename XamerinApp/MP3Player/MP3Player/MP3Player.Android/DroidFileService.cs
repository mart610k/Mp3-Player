using MP3Player.Classes;
using System.IO;
using MP3Player.Classes.Tracks;

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