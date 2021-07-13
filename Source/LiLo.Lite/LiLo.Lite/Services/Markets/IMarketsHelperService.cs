// <copyright file="IMarketsHelperService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Services.Markets
{
	using System.Threading.Tasks;
	using LiLo.Lite.Models.Markets;
	using WebSocketSharp;
	using Xamarin.CommunityToolkit.ObjectModel;

	/// <summary>Markets helper service.</summary>
	public interface IMarketsHelperService
	{
		/// <summary>Gets or sets a list of Markets.</summary>
		ObservableRangeCollection<MarketModel> MarketsList { get; set; }

		/// <summary>Get the WSS feed string.</summary>
		/// <returns>WSS URL.</returns>
		string GetWss();

		/// <summary>Initialises task for the markets helper service.</summary>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
		Task Init();

		/// <summary>Message received handler.</summary>
		/// <param name="sender">Message sender.</param>
		/// <param name="e">Message event arguments.</param>
		void WebSockets_OnMessageAsync(object sender, MessageEventArgs e);
	}
}