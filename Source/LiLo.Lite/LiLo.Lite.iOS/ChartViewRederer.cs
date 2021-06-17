//-----------------------------------------------------------------------
// <copyright file="ChartViewRederer.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   App Delegate.
// </summary>
//-----------------------------------------------------------------------

using Foundation;
using LiLo.Lite.iOS;
using LiLo.Lite.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ChartView), typeof(ChartViewRederer))]

namespace LiLo.Lite.iOS
{
	public class ChartViewRederer : PageRenderer
	{
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int)UIInterfaceOrientation.Unknown), new NSString("orientation"));
		}
	}
}