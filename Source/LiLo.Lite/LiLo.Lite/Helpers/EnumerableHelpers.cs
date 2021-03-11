// <copyright file="EnumerableHelpers.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>

namespace LiLo.Lite.Helpers
{
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using Xamarin.Forms.Internals;

	/// <summary>Enumerable helper.</summary>
	public static class EnumerableHelpers
	{
		/// <summary>To Observable collection.</summary>
		/// <typeparam name="T">Type.</typeparam>
		/// <param name="source">Source.</param>
		/// <returns>ObservableCollection{T}.</returns>
		public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
		{
			if (source == null)
			{
				return null;
			}

			ObservableCollection<T> result = new ObservableCollection<T>();
			source.ForEach(result.Add);
			return result;
		}
	}
}