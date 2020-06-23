//-----------------------------------------------------------------------
// <copyright file="VisibleItemsToHeightConverter.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Visible items to height converter.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Converters
{
	using System;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.Linq;
	using Lilo.Lite;
	using LiLo.Lite.Models.Markets;
	using Xamarin.Forms;

	/// <summary>Visible items to height converter.</summary>
	public class VisibleItemsToHeightConverter : IValueConverter
	{
		/// <summary>Covert the height of an element to the number of visible element items * height.</summary>
		/// <param name="value">Number of items</param>
		/// <param name="targetType">Target type</param>
		/// <param name="parameter">Conversion parameter.</param>
		/// <param name="culture">Culture of object.</param>
		/// <returns>Height of element.</returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is ObservableCollection<MarketsModel>)
			{
				ObservableCollection<MarketsModel> items = value as ObservableCollection<MarketsModel>;
				int visibleItems = items.Where(i => i.IsVisible).Count();
				return visibleItems * (GlobalSettings.MarketsItemHeight + GlobalSettings.MarketsItemHeightPadding);
			}

			return 0;
		}

		/// <summary>Converts the value object back to the target type and value.</summary>
		/// <param name="value">Value to convert.</param>
		/// <param name="targetType">Target type</param>
		/// <param name="parameter">Conversion parameter.</param>
		/// <param name="culture">Culture of object.</param>
		/// <returns>NULL as this is not offered!</returns>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}