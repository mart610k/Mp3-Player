using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MP3Player
{


    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        /// <summary>
        /// Provides a XAML way to obtain an image resource from an embedded Resource
        /// </summary>
        /// <param name="serviceProvider">Location of the file</param>
        /// <returns>object containing the Image source</returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            return imageSource;
        }

        /// <summary>
        /// Provides a code based way to obtain an image resource from Embedded resources
        /// </summary>
        /// <param name="sourceName">The path to the resource starting with namespace and folder path, all seperated by '.'(full stops) down to the filename</param>
        /// <returns>The image source for that location</returns>
        public static ImageSource GetImageSource(string sourceName)
        {
            if (sourceName == null)
            {
                return null;
            }

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(sourceName, typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}