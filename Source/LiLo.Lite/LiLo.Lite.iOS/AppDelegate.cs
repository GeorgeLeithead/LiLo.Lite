namespace LiLo.Lite.iOS
{
	using System.Linq;
	using Foundation;
	using LiLo.Lite.Views;
	using Microsoft.AppCenter.Distribute;
	using ObjCRuntime;
	using UIKit;
	using Xamarin.Forms;

	/// <summary>The UIApplicationDelegate for the application. This class is responsible for launching the User Interface of the application, as well as listening (and optionally responding) to application events from iOS.</summary>
	[Register("AppDelegate")]
	public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		/// <inheritdoc/>
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Forms.SetFlags("CollectionView_Experimental");
			Forms.Init();
			Distribute.DontCheckForUpdatesInDebug();
			LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}

		/// <inheritdoc/>
		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, [Transient] UIWindow forWindow)
		{
			Page mainpage = Xamarin.Forms.Application.Current.MainPage;
			if (mainpage.Navigation.NavigationStack.LastOrDefault() is ChartView)
			{
				return UIInterfaceOrientationMask.Portrait;
			}

			return UIInterfaceOrientationMask.All;
		}
	}
}