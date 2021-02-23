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
	using LiLo.Lite.ViewModels.Base;
	using Xamarin.Forms.Internals;

	/// <summary>Model for the Navigation List and Tile with Cards page.</summary>
	[Preserve(AllMembers = true)]
	[DataContract]
	public class MarketsModel : ViewModelBase
	{
		/// <summary>Format culture - set to US</summary>
		private readonly CultureInfo formatCulture = CultureInfo.CreateSpecificCulture("en-US");

		/// <summary>Number of decimal places</summary>
		private int decimalPlaces;

		/// <summary>24HR high price</summary>
		private double highPrice24h;

		/// <summary>24HR high price as string</summary>
		private string highPrice24hString;

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

		/// <summary>Maximum price</summary>
		private double maxprice;

		/// <summary>Maximum trading quantity</summary>
		private int maxtradingqty;

		/// <summary>Minimum price</summary>
		private double minprice;

		/// <summary>24HR price percentage</summary>
		private double price24hPercent;

		/// <summary>24HR price percentage as string</summary>
		private string price24hPercentString;

		/// <summary>Currency symbol as string</summary>
		private string symbolString;

		/// <summary>Tick size</summary>
		private double ticksize;

		/// <summary>Currency turnover</summary>
		private string turnover;

		/// <summary>24HR currency turnover</summary>
		private long turnover24h;

		/// <summary>Initialises a new instance of the <see cref="MarketsModel"/> class.</summary>
		public MarketsModel()
		{
			this.DecimalPlaces = 2;
			this.HighPrice24h = this.LowPrice24h = this.LastPrice = this.MarkPrice = this.Price24hPercent = this.Turnover24h = 0;
			this.HighPrice24hString = this.LowPrice24hString = this.LastPriceString = this.MarkPriceString = this.Price24hPercentString = "$0.00";
			this.Turnover = "0";
			this.LastTickDirection = string.Empty;
		}

		/// <summary>Gets or sets the number of decimal places to show for the currency.</summary>
		[DataMember(Name = "decimalPlaces")]
		public int DecimalPlaces
		{
			get => this.decimalPlaces;
			set
			{
				this.decimalPlaces = value;
				this.NotifyPropertyChanged(() => this.DecimalPlaces);
			}
		}

		/// <summary>Gets or sets the 24HR high price for the currency.</summary>
		public double HighPrice24h
		{
			get => this.highPrice24h;
			set
			{
				if (this.highPrice24h != value)
				{
					this.highPrice24h = value;
					this.HighPrice24hString = value.ToString("C" + this.DecimalPlaces, this.formatCulture);
					this.NotifyPropertyChanged(() => this.HighPrice24h);
				}
			}
		}

		/// <summary>Gets or sets the 24HR high price for the currency as string.</summary>
		public string HighPrice24hString
		{
			get => this.highPrice24hString;
			set
			{
				if (this.highPrice24hString != value)
				{
					this.highPrice24hString = value;
					this.NotifyPropertyChanged(() => this.HighPrice24hString);
				}
			}
		}

		/// <summary>Gets or sets the image of an item.</summary>
		[DataMember(Name = "itemImage")]
		public virtual string ItemImage
		{
			get => this.itemImage;
			set
			{
				if (this.itemImage != value)
				{
					this.itemImage = value;
					this.NotifyPropertyChanged(() => this.ItemImage);
				}
			}
		}

		/// <summary>Gets or sets the last price for the currency.</summary>
		public double LastPrice
		{
			get => this.lastPrice;
			set
			{
				if (this.lastPrice != value && value != 0)
				{
					this.lastPrice = value;
					this.LastPriceString = value.ToString("C" + this.DecimalPlaces, this.formatCulture);
					this.NotifyPropertyChanged(() => this.LastPrice);
				}
			}
		}

		/// <summary>Gets or sets the last price as a string</summary>
		public string LastPriceString
		{
			get => this.lastPriceString;
			set
			{
				if (this.lastPriceString != value)
				{
					this.lastPriceString = value;
					this.NotifyPropertyChanged(() => this.LastPriceString);
				}
			}
		}

		/// <summary>Gets or sets the last tick direction for the currency.</summary>
		public string LastTickDirection
		{
			get => string.IsNullOrEmpty(this.lastTickDirection) ? "PlusTick" : this.lastTickDirection;
			set
			{
				if (this.lastTickDirection != value)
				{
					this.lastTickDirection = value;
					this.NotifyPropertyChanged(() => this.LastTickDirection);
				}
			}
		}

		/// <summary>Gets or sets the 24HR low price for the currency.</summary>
		public double LowPrice24h
		{
			get => this.lowPrice24h;
			set
			{
				if (this.lowPrice24h != value)
				{
					this.lowPrice24h = value;
					this.LowPrice24hString = value.ToString("C" + this.DecimalPlaces, this.formatCulture);
					this.NotifyPropertyChanged(() => this.LowPrice24h);
				}
			}
		}

		/// <summary>Gets or sets the 24HR low price as a string</summary>
		public string LowPrice24hString
		{
			get => this.lowPrice24hString;
			set
			{
				if (this.lowPrice24hString != value)
				{
					this.lowPrice24hString = value;
					this.NotifyPropertyChanged(() => this.LowPrice24hString);
				}
			}
		}

		/// <summary>Gets or sets the mark price for the currency.</summary>
		public double MarkPrice
		{
			get => this.markPrice;
			set
			{
				if (this.markPrice != value)
				{
					this.markPrice = value;
					this.MarkPriceString = value.ToString("C" + this.DecimalPlaces, this.formatCulture);
					this.NotifyPropertyChanged(() => this.MarkPrice);
				}
			}
		}

		/// <summary>Gets or sets the mark price as a string</summary>
		public string MarkPriceString
		{
			get => this.markPriceString;
			set
			{
				if (this.markPriceString != value)
				{
					this.markPriceString = value;
					this.NotifyPropertyChanged(() => this.MarkPriceString);
				}
			}
		}

		/// <summary>Gets or sets the MAX price for the currency</summary>
		public double MaxPrice
		{
			get => this.maxprice;
			set
			{
				this.maxprice = value;
				this.NotifyPropertyChanged(() => this.MaxPrice);
			}
		}

		/// <summary>Gets or sets the MAX quantity for the currency</summary>
		public int MaxQuantity
		{
			get => this.maxtradingqty;
			set
			{
				this.maxtradingqty = value;
				this.NotifyPropertyChanged(() => this.MaxQuantity);
			}
		}

		/// <summary>Gets or sets the minimum price for the currency</summary>
		public double MinPrice
		{
			get => this.minprice;
			set
			{
				this.minprice = value;
				this.NotifyPropertyChanged(() => this.MinPrice);
			}
		}

		/// <summary>Gets or sets the 24HR percentage price difference for the currency.</summary>
		public double Price24hPercent
		{
			get => this.price24hPercent;
			set
			{
				if (this.price24hPercent != value)
				{
					this.price24hPercent = value;
					this.Price24hPercentString = value.ToString("F2", this.formatCulture);
					this.NotifyPropertyChanged(() => this.Price24hPercent);
				}
			}
		}

		/// <summary>Gets or sets the 24HR price percentage as a string</summary>
		public string Price24hPercentString
		{
			get => this.price24hPercentString;
			set
			{
				if (this.price24hPercentString != value)
				{
					this.price24hPercentString = value;
					this.NotifyPropertyChanged(() => this.Price24hPercentString);
				}
			}
		}

		/// <summary>Market ranking.</summary>
		public int Rank { get; set; }

		/// <summary>Gets or sets the currency Symbol as a string.</summary>
		[DataMember(Name = "symbol")]
		public string SymbolString
		{
			get => this.symbolString;
			set
			{
				if (this.symbolString != value)
				{
					this.symbolString = value;
					this.NotifyPropertyChanged(() => this.SymbolString);
				}
			}
		}

		/// <summary>Gets or sets the tick size for the currency</summary>
		public double TickSize
		{
			get => this.ticksize;
			set
			{
				this.ticksize = value;
				this.NotifyPropertyChanged(() => this.TickSize);
			}
		}

		/// <summary>Gets or sets the 24HR turn over for the currency in a friendly format.</summary>
		public string Turnover
		{
			get => this.turnover;
			set
			{
				if (this.turnover != value)
				{
					this.turnover = value;
					this.NotifyPropertyChanged(() => this.Turnover);
				}
			}
		}

		/// <summary>Gets or sets the 24HR turn over for the currency.</summary>
		public long Turnover24h
		{
			get => this.turnover24h;
			set
			{
				if (this.turnover24h != value)
				{
					this.turnover24h = value;
					this.Turnover = FormatNumber(value);
					this.NotifyPropertyChanged(() => this.Turnover24h);
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