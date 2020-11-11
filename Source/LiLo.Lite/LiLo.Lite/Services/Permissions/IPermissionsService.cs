//-----------------------------------------------------------------------
// <copyright file="IPermissionsService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Application permissions service interface.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Permissions
{
	using LiLo.Lite.Models.Permissions;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	/// <summary>Application permissions service interface.</summary>
	public interface IPermissionsService
	{
		/// <summary>Check permission status.</summary>
		/// <param name="permission">Permission to check.</param>
		/// <returns>Permission status.</returns>
		Task<PermissionStatus> CheckPermissionStatusAsync(Permission permission);

		/// <summary>Request permissions.</summary>
		/// <param name="permissions">Permissions to request.</param>
		/// <returns>Permission request status.</returns>
		Task<Dictionary<Permission, PermissionStatus>> RequestPermissionsAsync(params Permission[] permissions);
	}
}