//-----------------------------------------------------------------------
// <copyright file="AndroidParentWindowLocatorService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Main Activity.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Droid
{
	using LiLo.Lite.Interfaces;
	using Plugin.CurrentActivity;

	internal class AndroidParentWindowLocatorService : IParentWindowLocatorService
	{
		public object GetCurrentParentWindow()
		{
			return CrossCurrentActivity.Current.Activity;
		}
	}
}