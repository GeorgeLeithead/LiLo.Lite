// <copyright file="Constants.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Helpers
{
	/// <summary>Application constants.</summary>
	public static class Constants
	{
		/// <summary>AppCentre analytics class.</summary>
		public static class Analytics
		{
			/// <summary>Analytics events class.</summary>
			public static class Events
			{
				/// <summary>Favourites enabled tracking event.</summary>
				public const string FavouritesEnabled = "FavouritesEnabled";
			}
		}

		/// <summary>User preferences class.</summary>
		public static class Preferences
		{
			/// <summary>Preferences analytics.</summary>
			public const string Analytics = "Analytics";
		}

		/// <summary>Navigation class.</summary>
		public static class Navigation
		{
			/// <summary>Navigation paths class.</summary>
			public static class Paths
			{
				/// <summary>Home path.</summary>
				public const string Home = "home";

				/// <summary>Alert path.</summary>
				public const string Alert = "alerts";

				/// <summary>Chart path.</summary>
				public const string Chart = "chart";
			}
		}

		/// <summary>Views class.</summary>
		public static class Views
		{
			/// <summary>View controls class.</summary>
			public static class Controls
			{
				/// <summary>Retry control text.</summary>
				public const string Retry = "Retry";

				/// <summary>No markets data control text.</summary>
				public const string NoMarketData = "No market feed data...";

				/// <summary>Alerts coming soon control text.</summary>
				public const string AlertsComingSoon = "Create a new alert...(coming soon)";
			}
		}
	}
}