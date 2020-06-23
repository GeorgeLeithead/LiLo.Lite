//-----------------------------------------------------------------------
// <copyright file="Permission.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Permissions model.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Models.Permissions
{
	/// <summary>Permissions model.</summary>
	public enum Permission
	{
		/// <summary>Permission unknown</summary>
		Unknown,

		/// <summary>Permission for location.</summary>
		Location,

		/// <summary>Permission always.</summary>
		LocationAlways,

		/// <summary>Permission when application in use.</summary>
		LocationWhenInUse
	}
}