using Android.App;
using Android.Content;
using Android.OS;

using Application = Android.App.Application;

using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;

namespace WinDateCalc.Android;

[Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
public class SplashActivity : Activity
{
    protected override void OnResume()
    {
        base.OnResume();

        StartActivity(new Intent(global::Android.App.Application.Context, typeof(MainActivity)));
    }
}
