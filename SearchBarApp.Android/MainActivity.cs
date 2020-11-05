
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Xamarin.Forms.Platform.Android;

namespace SearchBarApp.Droid
{
    [Activity(Label = "SearchBarApp"
        , Icon = "@mipmap/icon"
        , Theme = "@style/MainTheme"
        , MainLauncher = true
        , ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            // set the layout resources first
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.Toolbar;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.Tabbar;

            // then call base.OnCreate and the Xamarin.Forms methods
            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.SetFlags("RadioButton_Experimental");

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}