// <copyright file="MarketModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Models.Markets
{
	using LiLo.Lite.ViewModels.Base;
	using System.Globalization;
	using System.Runtime.Serialization;
	using Xamarin.Forms;

	/// <summary>Model for the markets information.</summary>
	[Xamarin.Forms.Internals.Preserve(AllMembers = true)]
	[DataContract]
	public class MarketModel : ViewModelBase
	{
		/// <summary>Format culture - set to US.</summary>
		private readonly CultureInfo formatCulture = CultureInfo.CreateSpecificCulture("en-US");

		/// <summary>Number of decimal places.</summary>
		private int decimalPlaces;

		/// <summary>24HR high price.</summary>
		private double highPrice24h;

		/// <summary>24HR high price as string.</summary>
		private string highPrice24hString;

		/// <summary>Last price.</summary>
		private double lastPrice;

		/// <summary>Last price as string.</summary>
		private string lastPriceString;

		/// <summary>24HR low price.</summary>
		private double lowPrice24h;

		/// <summary>24HR low price as string.</summary>
		private string lowPrice24hString;

		/// <summary>24HR price percentage.</summary>
		private double price24hPercent;

		/// <summary>24HR price percentage as string.</summary>
		private string price24hPercentString;

		/// <summary>Currency symbol image.</summary>
		private UriImageSource symbolImage;

		/// <summary>Currency symbol as string.</summary>
		private string symbolString;

		/// <summary>Initialises a new instance of the <see cref="MarketModel"/> class.</summary>
		public MarketModel()
		{
			DecimalPlaces = 2;
			HighPrice24h = LowPrice24h = LastPrice = Price24hPercent = 0;
			HighPrice24hString = LowPrice24hString = LastPriceString = Price24hPercentString = "$0.00";
		}

		/// <summary>Gets or sets the number of decimal places to show for the currency.</summary>
		[DataMember(Name = "decimalPlaces")]
		public int DecimalPlaces
		{
			get => decimalPlaces;
			set
			{
				decimalPlaces = value;
				OnPropertyChanged(nameof(DecimalPlaces));
			}
		}

		/// <summary>Gets or sets the 24HR high price for the currency.</summary>
		public double HighPrice24h
		{
			get => highPrice24h;
			set
			{
				if (highPrice24h != value)
				{
					highPrice24h = value;
					HighPrice24hString = value.ToString("C" + DecimalPlaces, formatCulture);
					OnPropertyChanged(nameof(HighPrice24h));
				}
			}
		}

		/// <summary>Gets or sets the 24HR high price for the currency as string.</summary>
		public string HighPrice24hString
		{
			get => highPrice24hString;
			set
			{
				if (highPrice24hString != value)
				{
					highPrice24hString = value;
					OnPropertyChanged(nameof(HighPrice24hString));
				}
			}
		}

		/// <summary>Gets or sets the last price for the currency.</summary>
		public double LastPrice
		{
			get => lastPrice;
			set
			{
				if (lastPrice != value && value != 0)
				{
					lastPrice = value;
					LastPriceString = value.ToString("C" + DecimalPlaces, formatCulture);
					OnPropertyChanged(nameof(LastPrice));
				}
			}
		}

		/// <summary>Gets or sets the last price as a string.</summary>
		public string LastPriceString
		{
			get => lastPriceString;
			set
			{
				if (lastPriceString != value)
				{
					lastPriceString = value;
					OnPropertyChanged(nameof(LastPriceString));
				}
			}
		}

		/// <summary>Gets or sets the 24HR low price for the currency.</summary>
		public double LowPrice24h
		{
			get => lowPrice24h;
			set
			{
				if (lowPrice24h != value)
				{
					lowPrice24h = value;
					LowPrice24hString = value.ToString("C" + DecimalPlaces, formatCulture);
					OnPropertyChanged(nameof(LowPrice24h));
				}
			}
		}

		/// <summary>Gets or sets the 24HR low price as a string.</summary>
		public string LowPrice24hString
		{
			get => lowPrice24hString;
			set
			{
				if (lowPrice24hString != value)
				{
					lowPrice24hString = value;
					OnPropertyChanged(nameof(LowPrice24hString));
				}
			}
		}

		/// <summary>Gets or sets the 24HR percentage price difference for the currency.</summary>
		public double Price24hPercent
		{
			get => price24hPercent;
			set
			{
				if (price24hPercent != value)
				{
					price24hPercent = value;
					Price24hPercentString = value.ToString("F2", formatCulture);
					OnPropertyChanged(nameof(Price24hPercent));
				}
			}
		}

		/// <summary>Gets or sets the 24HR price percentage as a string.</summary>
		public string Price24hPercentString
		{
			get => price24hPercentString;
			set
			{
				if (price24hPercentString != value)
				{
					price24hPercentString = value;
					OnPropertyChanged(nameof(Price24hPercentString));
				}
			}
		}

		/// <summary>Gets or sets the market ranking for the symbol.</summary>
		public int Rank { get; set; }

		/// <summary>Gets or sets the currency symbol image.</summary>
		public UriImageSource SymbolImage
		{
			get => symbolImage;
			set
			{
				symbolImage = value;
				OnPropertyChanged(nameof(SymbolImage));
			}
		}

		/// <summary>Gets or sets the currency Symbol as a string.</summary>
		[DataMember(Name = "symbol")]
		public string SymbolString
		{
			get => symbolString;
			set
			{
				if (symbolString != value)
				{
					symbolString = value;
					OnPropertyChanged(nameof(SymbolString));
				}
			}
		}
	}
}