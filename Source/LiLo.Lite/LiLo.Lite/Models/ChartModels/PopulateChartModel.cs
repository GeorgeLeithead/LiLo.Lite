// <copyright file="PopulateChartModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Models.ChartModels
{
	using System.Collections.Generic;

	/// <summary>Populate chart model(s).</summary>
	public static class PopulateChartModel
	{
		/// <summary>Get the chart bar style.</summary>
		/// <returns>List{BarStyleMenu} of chart bar style.</returns>
		public static List<BarStyleModel> GetBarStyle()
		{
			List<BarStyleModel> barStyleModel = new()
			{
				new BarStyleModel { Name = "Bars", Value = "0" },
				new BarStyleModel { Name = "Candles", Value = "1" },
				new BarStyleModel { Name = "Hollow Candles", Value = "9" },
				new BarStyleModel { Name = "Heikin Ashi", Value = "8" },
				new BarStyleModel { Name = "Line", Value = "2" },
				new BarStyleModel { Name = "Area", Value = "3" },
				new BarStyleModel { Name = "Renko", Value = "4" },
				new BarStyleModel { Name = "Line Break", Value = "7" },
				new BarStyleModel { Name = "Kagi", Value = "5" },
				new BarStyleModel { Name = "Point and Figure", Value = "6" },
			};

			return barStyleModel;
		}

		/// <summary>Get the chart indicator.</summary>
		/// <returns>List{IndicatorModel} of chart indicators.</returns>
		public static List<IndicatorModel> GetIndicator()
		{
			List<IndicatorModel> indicatorModel = new()
			{
				new IndicatorModel { Value = string.Empty, Name = "-- NONE --" },
				new IndicatorModel { Value = "ACCD@tv-basicstudies", Name = "Accumulation/Distribution" },
				new IndicatorModel { Value = "studyADR@tv-basicstudies", Name = "ADR" },
				new IndicatorModel { Value = "AROON@tv-basicstudies", Name = "Aroon" },
				new IndicatorModel { Value = "ATR@tv-basicstudies", Name = "Average True Range" },
				new IndicatorModel { Value = "AwesomeOscillator@tv-basicstudies", Name = "Awesome Oscillator" },
				new IndicatorModel { Value = "BB@tv-basicstudies", Name = "Bollinger Bands" },
				new IndicatorModel { Value = "BollingerBandsR@tv-basicstudies", Name = "Bollinger Bands %B" },
				new IndicatorModel { Value = "BollingerBandsWidth@tv-basicstudies", Name = "Bollinger Bands Width" },
				new IndicatorModel { Value = "CMF@tv-basicstudies", Name = "Chaikin Money Flow" },
				new IndicatorModel { Value = "ChaikinOscillator@tv-basicstudies", Name = "Chaikin Oscillator" },
				new IndicatorModel { Value = "chandeMO@tv-basicstudies", Name = "Chande Momentum Oscillator" },
				new IndicatorModel { Value = "ChoppinessIndex@tv-basicstudies", Name = "Choppiness Index" },
				new IndicatorModel { Value = "CCI@tv-basicstudies", Name = "Commodity Channel Index" },
				new IndicatorModel { Value = "CRSI@tv-basicstudies", Name = "ConnorsRSI" },
				new IndicatorModel { Value = "CorrelationCoefficient@tv-basicstudies", Name = "Correlation Coefficient" },
				new IndicatorModel { Value = "DetrendedPriceOscillator@tv-basicstudies", Name = "Detrended Price Oscillator" },
				new IndicatorModel { Value = "DM@tv-basicstudies", Name = "Directional Movement" },
				new IndicatorModel { Value = "DONCH@tv-basicstudies", Name = "Donchian Channels" },
				new IndicatorModel { Value = "DoubleEMA@tv-basicstudies", Name = "Double EMA" },
				new IndicatorModel { Value = "EaseOfMovement@tv-basicstudies", Name = "Ease Of Movement" },
				new IndicatorModel { Value = "EFI@tv-basicstudies", Name = "Elder's Force Index" },
				new IndicatorModel { Value = "ENV@tv-basicstudies", Name = "Envelope" },
				new IndicatorModel { Value = "FisherTransform@tv-basicstudies", Name = "Fisher Transform" },
				new IndicatorModel { Value = "HV@tv-basicstudies", Name = "Historical Volatility" },
				new IndicatorModel { Value = "hullMA@tv-basicstudies", Name = "Hull Moving Average" },
				new IndicatorModel { Value = "IchimokuCloud@tv-basicstudies", Name = "Ichimoku Cloud" },
				new IndicatorModel { Value = "KLTNR@tv-basicstudies", Name = "Keltner Channels" },
				new IndicatorModel { Value = "KST@tv-basicstudies", Name = "Know Sure Thing" },
				new IndicatorModel { Value = "LinearRegression@tv-basicstudies", Name = "Linear Regression" },
				new IndicatorModel { Value = "MACD@tv-basicstudies", Name = "MACD" },
				new IndicatorModel { Value = "MOM@tv-basicstudies", Name = "Momentum" },
				new IndicatorModel { Value = "MF@tv-basicstudies", Name = "Money Flow" },
				new IndicatorModel { Value = "MoonPhases@tv-basicstudies", Name = "Moon Phases" },
				new IndicatorModel { Value = "MASimple@tv-basicstudies", Name = "Moving Average" },
				new IndicatorModel { Value = "MAExp@tv-basicstudies", Name = "Moving Average Exponential" },
				new IndicatorModel { Value = "MAWeighted@tv-basicstudies", Name = "Moving Average Weighted" },
				new IndicatorModel { Value = "OBV@tv-basicstudies", Name = "On Balance Volume" },
				new IndicatorModel { Value = "PSAR@tv-basicstudies", Name = "Parabolic SAR" },
				new IndicatorModel { Value = "PivotPointsHighLow@tv-basicstudies", Name = "Pivot Points High Low" },
				new IndicatorModel { Value = "PivotPointsStandard@tv-basicstudies", Name = "Pivot Points Standard" },
				new IndicatorModel { Value = "PriceOsc@tv-basicstudies", Name = "Price Oscillator" },
				new IndicatorModel { Value = "PriceVolumeTrend@tv-basicstudies", Name = "Price Volume Trend" },
				new IndicatorModel { Value = "ROC@tv-basicstudies", Name = "Rate Of Change" },
				new IndicatorModel { Value = "RSI@tv-basicstudies", Name = "Relative Strength Index" },
				new IndicatorModel { Value = "VigorIndex@tv-basicstudies", Name = "Relative Vigor Index" },
				new IndicatorModel { Value = "VolatilityIndex@tv-basicstudies", Name = "Relative Volatility Index" },
				new IndicatorModel { Value = "SMIErgodicIndicator@tv-basicstudies", Name = "SMI Ergodic Indicator" },
				new IndicatorModel { Value = "SMIErgodicOscillator@tv-basicstudies", Name = "SMI Ergodic Oscillator" },
				new IndicatorModel { Value = "Stochastic@tv-basicstudies", Name = "Stochastic" },
				new IndicatorModel { Value = "StochasticRSI@tv-basicstudies", Name = "Stochastic RSI" },
				new IndicatorModel { Value = "TripleEMA@tv-basicstudies", Name = "Triple EMA" },
				new IndicatorModel { Value = "Trix@tv-basicstudies", Name = "TRIX" },
				new IndicatorModel { Value = "UltimateOsc@tv-basicstudies", Name = "Ultimate Oscillator" },
				new IndicatorModel { Value = "VSTOP@tv-basicstudies", Name = "Volatility Stop" },
				new IndicatorModel { Value = "Volume@tv-basicstudies", Name = "Volume" },
				new IndicatorModel { Value = "VWAP@tv-basicstudies", Name = "VWAP" },
				new IndicatorModel { Value = "MAVolumeWeighted@tv-basicstudies", Name = "VWMA" },
				new IndicatorModel { Value = "WilliamR@tv-basicstudies", Name = "Williams %R" },
				new IndicatorModel { Value = "WilliamsAlligator@tv-basicstudies", Name = "Williams Alligator" },
				new IndicatorModel { Value = "WilliamsFractal@tv-basicstudies", Name = "Williams Fractal" },
				new IndicatorModel { Value = "ZigZag@tv-basicstudies", Name = "Zig Zag" },
			};

			return indicatorModel;
		}

		/// <summary>Get the chart interval.</summary>
		/// <returns>List{IntervalModel} of chart interval.</returns>
		public static List<IntervalModel> GetInterval()
		{
			List<IntervalModel> intervalModel = new()
			{
				new IntervalModel { Name = "1m", Value = "1" },
				new IntervalModel { Name = "3m", Value = "3" },
				new IntervalModel { Name = "5m", Value = "5" },
				new IntervalModel { Name = "15m", Value = "15" },
				new IntervalModel { Name = "30m", Value = "30" },
				new IntervalModel { Name = "1h", Value = "60" },
				new IntervalModel { Name = "2h", Value = "120" },
				new IntervalModel { Name = "3h", Value = "180" },
				new IntervalModel { Name = "4h", Value = "240" },
				new IntervalModel { Name = "1d", Value = "D" },
				new IntervalModel { Name = "1w", Value = "W" },
			};

			return intervalModel;
		}
	}
}