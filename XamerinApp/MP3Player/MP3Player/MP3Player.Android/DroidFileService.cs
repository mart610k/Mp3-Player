using MP3Player.Classes;
using System.IO;
using MP3Player.Classes.Tracks;
using System;
using System.Collections.Generic;

namespace MP3Player.Droid
{
    public class DroidFileService : IFileService
    {
        private string basePath;

        /// <summary>
        /// Gets the public external folder of the android device which gives the location of the folder based on the location passed in
        /// </summary>
        /// <param name="path"></param>
        public DroidFileService(string path, bool preferExternalStorage = true)
        {
            
            string[] directories = GetRootStorageLocations();
            ////TODO: This is hardcoded for now to make way for better testing.
            if (directories.Length == 1)
            {
                basePath = Path.Combine(directories[0],path);
            }
            else if (preferExternalStorage)
            {
                basePath = Path.Combine(directories[1], path);
            }
            else
            {
                basePath = Path.Combine(directories[0], path);
            }

            Console.WriteLine(basePath);
            CreateFolderLocationIfNotExist();
        }
        

        private string[] GetRootStorageLocations()
        {
            List<string> directories = new List<string>();
            foreach (string dir in MainActivity.GetAndroidContext().GetExternalFilesDirs(null))
            {
                directories.Add(dir);
            }
            return directories.ToArray();
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
            Console.WriteLine(basePath);
            return Directory.GetFiles(basePath, "*."+ fileExtension,SearchOption.AllDirectories);
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