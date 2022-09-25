using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.AppCompat.App;
using System.Threading.Tasks;
using WeatherApp.Droid;

namespace RsMobile.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash",
        Icon = "@mipmap/ic_launcher",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        MainLauncher = true,
        NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }




        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { Startup(); });
            startupWork.Start();
        }


        async void Startup()
        {
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}