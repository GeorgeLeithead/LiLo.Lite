// <copyright file="Constants.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Helpers
{
	/// <summary>Application constants.</summary>
	public static class Constants
	{
		/// <summary>AppCentre analytics class constants.</summary>
		public static class Analytics
		{
			/// <summary>Analytics events class constants.</summary>
			public static class Events
			{
				/// <summary>Favourites enabled tracking event.</summary>
				public const string FavouritesEnabled = "FavouritesEnabled";

				/// <summary>Show Symbol Labels tracking event.</summary>
				public const string ShowSymbolLabels = "ShowSymbolLabels";
			}
		}

		/// <summary>Navigation class constants.</summary>
		public static class Navigation
		{
			/// <summary>Navigation paths class constants.</summary>
			public static class Paths
			{
				/// <summary>Alert path.</summary>
				public const string Alert = "alerts";

				/// <summary>Chart path.</summary>
				public const string Chart = "chart";

				/// <summary>Favourites path.</summary>
				public const string Favourites = "favourites";

				/// <summary>Home path.</summary>
				public const string Home = "home";

				/// <summary>Settings path.</summary>
				public const string Settings = "settings";
			}
		}

		/// <summary>User preferences class constants.</summary>
		public static class Preferences
		{
			/// <summary>Preferences analytics.</summary>
			public const string Analytics = "Analytics";

			/// <summary>Chart preferences class constants.</summary>
			public static class Chart
			{
				/// <summary>Chart bar Style preference name.</summary>
				public const string ChartBarStyle = "ChartBarStyle";

				/// <summary>Chart bar style preference default value.</summary>
				public const string ChartBaryDefaultValue = "1";

				/// <summary>Chart interval preference name.</summary>
				public const string ChartInterval = "ChartInterval";

				/// <summary>Chart interval preference default value.</summary>
				public const string ChartIntervalDefaultValue = "15";

				/// <summary>Chart study indicator preference name.</summary>
				public const string ChartStudyIndicator = "ChartStudyIndicator";

				/// <summary>Chart study indicator preference default value.</summary>
				public const string ChartStudyIndicatorDefaultValue = "RSI@tv-basicstudies";

				/// <summary>Chart tool bar preference name.</summary>
				public const string ChartToolBar = "ChartToolBar";

				/// <summary>Chart tool bar preference default value.</summary>
				public const bool ChartToolBarDefaultValue = true;
			}

			/// <summary>Favourites preferences class constants.</summary>
			public static class Favourites
			{
				/// <summary>User saved favourites preference name.</summary>
				public const string FavouritesCategory = "Favourites";

				/// <summary>User saved favourites preference default value.</summary>
				public const string FavouritesCategoryDefaultValue = "";

				/// <summary>Favourites enabled preference name.</summary>
				public const string FavouritesEnabled = "FavouritesEnabled";

				/// <summary>Favourites enabled preference default value.</summary>
				public const bool FavouritesEnabledDefaultValue = false;

				/// <summary>User unloved favourites preference name.</summary>
				public const string UnlovedCategory = "Unloved";
			}

			/// <summary>Settings preferences class constants.</summary>
			public static class Settings
			{
				/// <summary>User theme preference name.</summary>
				public const string Theme = "Theme";

				/// <summary>User theme preference default value.</summary>
				public const int ThemeDefaultValue = 0;
			}
		}

		/// <summary>Sources for application files.</summary>
		public static class Sources
		{
			/// <summary>Source for icons.</summary>
			public static class Icons
			{
				/// <summary>Android icon source.</summary>
				public const string DroidSource = "https://www.internetwideworld.com/Images/Droid/drawable-xxxhdpi/{0}.png";

				/// <summary>IOS icon source.</summary>
				public const string IosSource = "https://www.internetwideworld.com/Images/iOS/{0}@3x.png";

				/// <summary>Cache duration in days.</summary>
				public const int CacheDuration = 30;
			}

			/// <summary>Source for market data feed.</summary>
			public static class MarketFeed
			{
				/// <summary>Data feed separator.</summary>
				public const string DataFeedSeparator = "usdt@ticker/";

				/// <summary>Default market feed.</summary>
				public const string Default = "https://raw.githubusercontent.com/GeorgeLeithead/LiLo.Markets/main/Markets.json";

				/// <summary>Versioned market feed.</summary>
				public const string Versioned = "https://raw.githubusercontent.com/GeorgeLeithead/LiLo.Markets/main/Markets{0}.json";

				/// <summary>Secure-WebSockets data feed.</summary>
				public const string WssData = "wss://stream.binance.com:9443/stream?streams=";
			}
		}
	}
}