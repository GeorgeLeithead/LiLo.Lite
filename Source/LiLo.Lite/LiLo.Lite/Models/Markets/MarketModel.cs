//-----------------------------------------------------------------------
// <copyright file="MarketModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Model for the markets information.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Models.Markets
{
	using System.Globalization;
	using System.Runtime.Serialization;
	using LiLo.Lite.ViewModels.Base;
	using Xamarin.Forms.Internals;

	/// <summary>Model for the markets information.</summary>
	[Preserve(AllMembers = true)]
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

		/// <summary>Currency symbol as string.</summary>
		private string symbolString;

		/// <summary>Initialises a new instance of the <see cref="MarketModel"/> class.</summary>
		public MarketModel()
		{
			this.DecimalPlaces = 2;
			this.HighPrice24h = this.LowPrice24h = this.LastPrice = this.Price24hPercent = 0;
			this.HighPrice24hString = this.LowPrice24hString = this.LastPriceString = this.Price24hPercentString = "$0.00";
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

		/// <summary>Gets or sets the last price as a string.</summary>
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

		/// <summary>Gets or sets the 24HR low price as a string.</summary>
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

		/// <summary>Gets or sets the 24HR price percentage as a string.</summary>
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

		/// <summary>Gets or sets the market ranking for the symbol.</summary>
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
	}
}