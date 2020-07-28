//-----------------------------------------------------------------------
// <copyright file="ChartView.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Chart View class.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Views
{
	using LiLo.Lite.Services.Navigation;
	using LiLo.Lite.ViewModels;
	using LiLo.Lite.ViewModels.Base;
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;
	using Xamarin.Forms.Xaml;
	using PanCardView;
	using System.Collections.Generic;
	using Microsoft.AppCenter.Analytics;
	using Lilo.Lite;
	using System;
	using System.Globalization;

	/// <summary>Chart View class.</summary>
	[Preserve(AllMembers = true)]
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChartView : ContentPage
	{
		/// <summary>Initialises a new instance of the <see cref="ChartView" /> class.</summary>
		public ChartView() => InitializeComponent();

		/// <summary>Handle the device back button being pressed.</summary>
		/// <remarks>As this is the root page, we have to prevent the back button otherwise it will exit the application.</remarks>
		/// <returns>true; cancellation of back button.</returns>
		protected override bool OnBackButtonPressed()
		{
			base.OnBackButtonPressed();
			INavigationService navigationService = ViewModelLocator.Resolve<INavigationService>();

			navigationService.NavigateToAsync<HomeViewModel>().ConfigureAwait(true);
			return true; // prevent users from clicking the back button and exiting the application from the root page.
		}

		/// <summary>Navigating in the Web view</summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Web navigation Event arguments.</param>
		/// <remarks>Prevent users from navigating to anywhere else other than where we want.</remarks>
		private void WebView_Navigating(object sender, WebNavigatingEventArgs e) => e.Cancel = true;

		private static HtmlWebViewSource WebViewSource(string symbol)
		{
			string colorTheme = Application.Current.UserAppTheme == OSAppTheme.Dark ? "dark" : "light";
			HtmlWebViewSource htmlViewSource = new HtmlWebViewSource() { Html = GlobalSettings.TradingViewWebViewSource.Html.Replace("XX0XX", symbol).Replace("XX1XX", TimeZoneInfo.Local.ToString()).Replace("XX2XX", colorTheme).Replace("XX3XX", CultureInfo.CurrentCulture.IetfLanguageTag.Substring(0, 2)) };
			return htmlViewSource;
		}

		/// <summary>Transition effect when the cover flow view item has appeared.</summary>
		/// <param name="view">Cards view object</param>
		/// <param name="args">Item appeared event arguments.</param>
		private async void OnCoverFlowViewItemAppeared(CardsView view, PanCardView.EventArgs.ItemAppearedEventArgs args)
		{
			Frame frame = view.CurrentView as Frame;
			StackLayout stackLayoutFrame = frame.Children[0] as StackLayout;
			await stackLayoutFrame.Children[0].ScaleTo(1.1, 200, Easing.CubicInOut);
			await stackLayoutFrame.Children[0].ScaleTo(1, 500, Easing.CubicIn);
			StackLayout stackLayoutContainer = frame.Parent.Parent as StackLayout;
			WebView webView = stackLayoutContainer.Children[stackLayoutContainer.Children.Count - 1] as WebView;
			if (webView.Source == null)
			{
				webView.Source = WebViewSource(frame.AutomationId);
			} else
			{
				string javaScript = $"CreateChart('BINANCE:{frame.AutomationId}');";
				await webView.EvaluateJavaScriptAsync(javaScript);
			}
			if (args.Index == 0)
			{
				Dictionary<string, string> selectedCurrencyAnalytic = new Dictionary<string, string>
				{
					{ "Currency", frame.AutomationId }
				};
				Analytics.TrackEvent("Market", selectedCurrencyAnalytic);
			}
		}
	}
}