//-----------------------------------------------------------------------
// <copyright file="PermissionStatus.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Permissions status model.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Models.Permissions
{
	/// <summary>Permissions status model.</summary>
	public enum PermissionStatus
	{
		/// <summary>Permission denied.</summary>
		Denied,

		/// <summary>Permission disabled.</summary>
		Disabled,

		/// <summary>Permission granted.</summary>
		Granted,

		/// <summary>Permission restricted.</summary>
		Restricted,

		/// <summary>Permission status unknown.</summary>
		Unknown,
	}
}