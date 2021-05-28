using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android;
using System;
using Xamarin.Forms;
using MP3Player.Classes;

namespace MP3Player.Droid
{
    [Activity(Label = "MP3Player", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IMessagePublisher
    {
        readonly string[] PermissionFileReadWrite =
        {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage
        };

        readonly int PermissionFileReadWriteCode = 1337;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            RequestPermissions(PermissionFileReadWrite, PermissionFileReadWriteCode);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
           
            
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (PermissionFileReadWriteCode == requestCode)
            {
                MessagingCenter.Send<IMessagePublisher>(this, "PermissionFileReadWrite");
            }
        }
    }
}