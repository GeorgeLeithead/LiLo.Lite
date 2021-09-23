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

				/// <summary>User favourite ordered currency preference name.</summary>
				public const string FavouriteOrderedCurrency = "FavouriteOrderedCurrency";

				/// <summary>User saved favourites preference default value.</summary>
				public const string FavouritesCategoryDefaultValue = "";

				/// <summary>Favourites enabled preference name.</summary>
				public const string FavouritesEnabled = "FavouritesEnabled";

				/// <summary>Favourites enabled preference default value.</summary>
				public const bool FavouritesEnabledDefaultValue = false;

				/// <summary>User unloved favourites preference name.</summary>
				public const string UnlovedCategory = "Unloved";

				/// <summary>Favourites changed flag preference name.</summary>
				public const string FavouritesChanged = "FavouritesChanged";
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
	}
}