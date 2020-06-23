//-----------------------------------------------------------------------
// <copyright file="IMarketsService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Markets service interface.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Markets
{
	using System.Collections.ObjectModel;
	using System.Threading.Tasks;
	using LiLo.Lite.Models.Markets;

	/// <summary>Markets service interface.</summary>
	public interface IMarketsService
	{
		/// <summary>Generates a list of all available markets.</summary>
		/// <returns>Task{ObservableCollection{MarketsModel}} of markets.</returns>
		Task<ObservableCollection<MarketsModel>> GetMarketsAsync();
	}
}