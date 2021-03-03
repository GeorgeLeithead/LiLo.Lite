
namespace LiLo.Lite.Droid
{
	using Android.App;
	using Android.Content;
	using Android.OS;
	using Android.Util;
	using AndroidX.AppCompat.App;
	using System.Threading.Tasks;

	/// <summary>Splash screen activity.</summary>
	[Activity(Theme = "@style/MainTheme.Splash", Icon = "@mipmap/icon", MainLauncher = true, NoHistory = true)]
	public class SplashActivity : AppCompatActivity
	{
		static readonly string TAG = "X:" + typeof(SplashActivity).Name;

		/// <inheritdoc/>
		public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
		{
			base.OnCreate(savedInstanceState, persistentState);
			Log.Debug(TAG, "SplashActivity.OnCreate");
		}

		/// <summary>Launches the start-up task.</summary>summary>
		protected override void OnResume()
		{
			base.OnResume();
			Task startupWork = new Task(() => { this.SimulateStartup(); });
			startupWork.Start();
		}

		/// <summary>Simulates background work that happens behind the splash screen.</summary>
		async void SimulateStartup()
		{
			Log.Debug(TAG, "Performing some start-up work that takes a bit of time.");
			await Task.Delay(500); // Simulate a bit of start-up work.
			Log.Debug(TAG, "Start-up work is finished - starting MainActivity.");
			this.StartActivity(new Intent(Application.Context, typeof(MainActivity)));
		}
	}
}