//-----------------------------------------------------------------------
// <copyright file="InverseBoolConverter.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Inverse bool converter.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Converters
{
	using System;
	using System.Globalization;
	using Xamarin.Forms;

	/// <summary>Inverse bool converter.</summary>
	/// <remarks>Used in bindings to invert the bound boolean value.</remarks>
	public class InverseBoolConverter : IValueConverter
	{
		/// <summary>Converts the value object to the target type and value.</summary>
		/// <param name="value">Value to convert.</param>
		/// <param name="targetType">Target type</param>
		/// <param name="parameter">Conversion parameter.</param>
		/// <param name="culture">Culture of object.</param>
		/// <returns>Inverted boolean</returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is bool))
			{
				throw new InvalidOperationException("The target must be a boolean");
			}

			return !(bool)value;
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