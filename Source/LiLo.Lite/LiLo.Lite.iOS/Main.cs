//-----------------------------------------------------------------------
// <copyright file="Main.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   App Delegate.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.iOS
{
	using UIKit;

	public class Application
	{
		/// <summary>This is the main entry point of the application.</summary>
		/// <param name="args">Start-up arguments.</param>
		/// <remarks>If you want to use a different Application Delegate class from "AppDelegate" you can specify it here.</remarks>
		[System.Obsolete]
		private static void Main(string[] args)
		{
			UIApplication.Main(args, null, "AppDelegate");
		}
	}
}