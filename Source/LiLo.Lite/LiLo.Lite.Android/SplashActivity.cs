//-----------------------------------------------------------------------
// <copyright file="SplashActivity.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Main Activity.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Droid
{
	using System.Threading.Tasks;
	using Android.App;
	using Android.Content;
	using Android.OS;
	using Android.Util;
	using AndroidX.AppCompat.App;

	/// <summary>Splash screen activity.</summary>
	[Activity(Theme = "@style/MainTheme.Splash", MainLauncher = true, NoHistory = true)]
	public class SplashActivity : AppCompatActivity
	{
		private static readonly string TAG = "X:" + nameof(SplashActivity);

		/// <inheritdoc/>
		public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
		{
			base.OnCreate(savedInstanceState, persistentState);
			_ = Log.Debug(TAG, "SplashActivity.OnCreate");
		}

		/// <summary>Launches the start-up task.</summary>summary>
		protected override void OnResume()
		{
			base.OnResume();
			Task startupWork = new Task(() => { this.SimulateStartup(); });
			startupWork.Start();
		}

		/// <summary>Simulates background work that happens behind the splash screen.</summary>
		private async void SimulateStartup()
		{
			_ = Log.Debug(TAG, "Performing some start-up work that takes a bit of time.");
			await Task.Delay(500); // Simulate a bit of start-up work.
			_ = Log.Debug(TAG, "Start-up work is finished - starting MainActivity.");
			this.StartActivity(new Intent(Application.Context, typeof(MainActivity)));
		}
	}
}