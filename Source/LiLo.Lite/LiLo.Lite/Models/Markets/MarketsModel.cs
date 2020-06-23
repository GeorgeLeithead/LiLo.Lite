//-----------------------------------------------------------------------
// <copyright file="MarketsModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Model for the Navigation List and Tile with Cards page.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Models.Markets
{
	using System;
	using System.Globalization;
	using System.Runtime.Serialization;
	using LiLo.Lite.Definitions;
	using LiLo.Lite.ViewModels.Base;
	using Xamarin.Forms.Internals;

	/// <summary>Model for the Navigation List and Tile with Cards page.</summary>
	[Preserve(AllMembers = true)]
	[DataContract]
	public class MarketsModel : ViewModelBase
	{
		/// <summary>Format culture - set to US</summary>
		private readonly CultureInfo formatCulture = CultureInfo.CreateSpecificCulture("en-US");

		/// <summary>Currency ENUM</summary>
		private CurrencyEnum currency;

		/// <summary>Currency string</summary>
		private string currencyString;

		/// <summary>Number of decimal places</summary>
		private int decimalPlaces;

		/// <summary>24HR high price</summary>
		private double highPrice24h;

		/// <summary>24HR high price as string</summary>
		private string highPrice24hString;

		/// <summary>Market visibility</summary>
		private bool isVisible;

		/// <summary>Market image/icon</summary>
		private string itemImage;

		/// <summary>Last price</summary>
		private double lastPrice;

		/// <summary>Last price as string</summary>
		private string lastPriceString;

		/// <summary>Last tick direction</summary>
		private string lastTickDirection;

		/// <summary>24HR low price</summary>
		private double lowPrice24h;

		/// <summary>24HR low price as string</summary>
		private string lowPrice24hString;

		/// <summary>Mark price</summary>
		private double markPrice;

		/// <summary>Mark price as string</summary>
		private string markPriceString;

		/// <summary>Maximum trading quantity</summary>
		private int maxtradingqty;

		/// <summary>Minimum price</summary>
		private double minprice;

		/// <summary>Maximum price</summary>
		private double maxprice;

		/// <summary>Tick size</summary>
		private double ticksize;

		/// <summary>1HR price percentage</summary>
		private double price1hPercent;

		/// <summary>1HR price percentage as string</summary>
		private string price1hPercentString;

		/// <summary>24HR price percentage</summary>
		private double price24hPercent;

		/// <summary>24HR price percentage as string</summary>
		private string price24hPercentString;

		/// <summary>Currency symbol as string</summary>
		private string symbolString;

		/// <summary>Currency turnover</summary>
		private string turnover;

		/// <summary>24HR currency turnover</summary>
		private long turnover24h;

		/// <summary>Initialises a new instance of the <see cref="MarketsModel"/> class.</summary>
		public MarketsModel()
		{
			DecimalPlaces = 2;
			HighPrice24h = LowPrice24h = LastPrice = MarkPrice = Price1hPercent = Price24hPercent = Turnover24h = 0;
			HighPrice24hString = LowPrice24hString = LastPriceString = MarkPriceString = Price1hPercentString = Price24hPercentString = "$0.00";
			Turnover = "0";
			LastTickDirection = string.Empty;
			IsVisible = true;
		}

		/// <summary>Gets or sets the currency.</summary>
		public CurrencyEnum Currency
		{
			get => currency;
			set
			{
				if (Currency != value)
				{
					currency = value;
					NotifyPropertyChanged(() => Currency);
				}
			}
		}

		/// <summary>Gets or sets the currency.</summary>
		[DataMember(Name = "currency")]
		public string CurrencyString
		{
			get => currencyString;
			set
			{
				if (currencyString != value)
				{
					currencyString = value;
					Currency = (CurrencyEnum)Enum.Parse(typeof(CurrencyEnum), value);
					NotifyPropertyChanged(() => CurrencyString);
				}
			}
		}

		/// <summary>Gets or sets the number of decimal places to show for the currency.</summary>
		[DataMember(Name = "decimalPlaces")]
		public int DecimalPlaces
		{
			get => decimalPlaces;
			set
			{
				decimalPlaces = value;
				NotifyPropertyChanged(() => DecimalPlaces);
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
					NotifyPropertyChanged(() => HighPrice24h);
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
					NotifyPropertyChanged(() => HighPrice24hString);
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether the market is visible.</summary>
		public bool IsVisible
		{
			get => isVisible;
			set
			{
				if (isVisible != value)
				{
					isVisible = value;
					NotifyPropertyChanged(() => IsVisible);
				}
			}
		}

		/// <summary>Gets or sets the image of an item.</summary>
		[DataMember(Name = "itemImage")]
		public virtual string ItemImage
		{
			get => itemImage;
			set
			{
				if (itemImage != value)
				{
					itemImage = value;
					NotifyPropertyChanged(() => ItemImage);
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
					NotifyPropertyChanged(() => LastPrice);
				}
			}
		}

		/// <summary>Gets or sets the last price as a string</summary>
		public string LastPriceString
		{
			get => lastPriceString;
			set
			{
				if (lastPriceString != value)
				{
					lastPriceString = value;
					NotifyPropertyChanged(() => LastPriceString);
				}
			}
		}

		/// <summary>Gets or sets the last tick direction for the currency.</summary>
		public string LastTickDirection
		{
			get => string.IsNullOrEmpty(lastTickDirection) ? "PlusTick" : lastTickDirection;
			set
			{
				if (lastTickDirection != value)
				{
					lastTickDirection = value;
					NotifyPropertyChanged(() => LastTickDirection);
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
					NotifyPropertyChanged(() => LowPrice24h);
				}
			}
		}

		/// <summary>Gets or sets the 24HR low price as a string</summary>
		public string LowPrice24hString
		{
			get => lowPrice24hString;
			set
			{
				if (lowPrice24hString != value)
				{
					lowPrice24hString = value;
					NotifyPropertyChanged(() => LowPrice24hString);
				}
			}
		}

		/// <summary>Gets or sets the mark price for the currency.</summary>
		public double MarkPrice
		{
			get => markPrice;
			set
			{
				if (markPrice != value)
				{
					markPrice = value;
					MarkPriceString = value.ToString("C" + DecimalPlaces, formatCulture);
					NotifyPropertyChanged(() => MarkPrice);
				}
			}
		}

		/// <summary>Gets or sets the mark price as a string</summary>
		public string MarkPriceString
		{
			get => markPriceString;
			set
			{
				if (markPriceString != value)
				{
					markPriceString = value;
					NotifyPropertyChanged(() => MarkPriceString);
				}
			}
		}

		/// <summary>Gets or sets the max price for the currency</summary>
		public double MaxPrice
		{
			get => maxprice;
			set
			{
				maxprice = value;
				NotifyPropertyChanged(() => MaxPrice);
			}
		}

		/// <summary>Gets or sets the max quantity for the currency</summary>
		public int MaxQuantity
		{
			get => maxtradingqty;
			set
			{
				maxtradingqty = value;
				NotifyPropertyChanged(() => MaxQuantity);
			}
		}

		/// <summary>Gets or sets the minimum price for the currency</summary>
		public double MinPrice
		{
			get => minprice;
			set
			{
				minprice = value;
				NotifyPropertyChanged(() => MinPrice);
			}
		}

		/// <summary>Gets or sets the 1HR percentage price difference for the currency.</summary>
		public double Price1hPercent
		{
			get => price1hPercent;
			set
			{
				if (price1hPercent != value)
				{
					price1hPercent = value;
					Price1hPercentString = value.ToString("F2", formatCulture);
					NotifyPropertyChanged(() => Price1hPercent);
				}
			}
		}

		/// <summary>Gets or sets the 1HR price percentage as a string</summary>
		public string Price1hPercentString
		{
			get => price1hPercentString;
			set
			{
				if (price1hPercentString != value)
				{
					price1hPercentString = value;
					NotifyPropertyChanged(() => Price1hPercentString);
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
					NotifyPropertyChanged(() => Price24hPercent);
				}
			}
		}

		/// <summary>Gets or sets the 24HR price percentage as a string</summary>
		public string Price24hPercentString
		{
			get => price24hPercentString;
			set
			{
				if (price24hPercentString != value)
				{
					price24hPercentString = value;
					NotifyPropertyChanged(() => Price24hPercentString);
				}
			}
		}

		/// <summary>Gets or sets the currency Symbol.</summary>
		public SymbolEnum Symbol { get; set; }

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
					Symbol = (SymbolEnum)Enum.Parse(typeof(SymbolEnum), value);
					NotifyPropertyChanged(() => SymbolString);
				}
			}
		}

		/// <summary>Gets or sets the tick size for the currency</summary>
		public double TickSize
		{
			get => ticksize;
			set
			{
				ticksize = value;
				NotifyPropertyChanged(() => TickSize);
			}
		}

		/// <summary>Gets or sets the 24HR turn over for the currency in a friendly format.</summary>
		public string Turnover
		{
			get => turnover;
			set
			{
				if (turnover != value)
				{
					turnover = value;
					NotifyPropertyChanged(() => Turnover);
				}
			}
		}

		/// <summary>Gets or sets the 24HR turn over for the currency.</summary>
		public long Turnover24h
		{
			get => turnover24h;
			set
			{
				if (turnover24h != value)
				{
					turnover24h = value;
					Turnover = FormatNumber(value);
					NotifyPropertyChanged(() => Turnover24h);
				}
			}
		}

		/// <summary>Formats a long number into a friendly denomination.</summary>
		/// <param name="num">Number to format</param>
		/// <returns>Friendly formatted string for the number.</returns>
		private static string FormatNumber(long num)
		{
			num = MaxThreeSignificantDigits(num);

			if (num >= 100000000)
			{
				return (num / 1000000D).ToString("0.#M");
			}

			if (num >= 1000000)
			{
				return (num / 1000000D).ToString("0.##M");
			}

			if (num >= 100000)
			{
				return (num / 1000D).ToString("0k");
			}

			if (num >= 100000)
			{
				return (num / 1000D).ToString("0.#k");
			}

			return num >= 1000 ? (num / 1000D).ToString("0.##k") : num.ToString("#,0");
		}

		/// <summary>Rounds a long to 3 significant digits.</summary>
		/// <param name="num">Number to round.</param>
		/// <returns>Rounded to 3 digits number.</returns>
		private static long MaxThreeSignificantDigits(long num)
		{
			int i = (int)Math.Log10(num);
			i = Math.Max(0, i - 2);
			i = (int)Math.Pow(10, i);
			return num / i * i;
		}
	}
}