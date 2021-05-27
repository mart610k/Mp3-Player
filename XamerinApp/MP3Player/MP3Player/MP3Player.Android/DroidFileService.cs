using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MP3Player.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
    }
}