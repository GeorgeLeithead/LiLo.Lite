// <copyright file="EnumerableHelpers.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
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

			ObservableCollection<T> result = new();
			source.ForEach(result.Add);
			return result;
		}
	}
}