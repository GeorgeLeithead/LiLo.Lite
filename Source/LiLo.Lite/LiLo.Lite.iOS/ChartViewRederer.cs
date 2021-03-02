using Foundation;
using LiLo.Lite.iOS;
using LiLo.Lite.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ChartView), typeof(ChartViewRederer))]
namespace LiLo.Lite.iOS
{
	public class ChartViewRederer: PageRenderer
	{
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int)(UIInterfaceOrientation.Unknown)), new NSString("orientation"));
		}
	}
}