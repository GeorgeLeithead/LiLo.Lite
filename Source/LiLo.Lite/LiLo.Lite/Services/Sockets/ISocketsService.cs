//-----------------------------------------------------------------------
// <copyright file="ISocketsService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Web Sockets Service interface.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Sockets
{
	using System.ComponentModel;
	using System.Threading.Tasks;

	/// <summary>Web Sockets Service interface.</summary>
	public interface ISocketsService
	{
		/// <summary>Raised when a public property of this object is set.</summary>
		event PropertyChangedEventHandler PropertyChanged;

		/// <summary>Gets a value indicating whether the sockets service is connected.</summary>
		bool IsConnected { get; }

		/// <summary>Initialises task for the sockets service.</summary>
		/// <returns>Task results of initialisation.</returns>
		Task InitAsync();

		/// <summary>Handle when the application closes the sockets connection.</summary>
		/// <returns>Successful task</returns>
		Task WebSocket_Close();

		/// <summary>Handle when the application requests a sockets connection.</summary>
		/// <returns>Successful task.</returns>
		Task WebSocket_OnConnect();

		/// <summary>Handle when the application resumes from sleep.</summary>
		/// <returns>Successful task</returns>
		Task WebSocket_OnResume();

		/// <summary>Handle when the application goes into sleep.</summary>
		/// <returns>Successful task</returns>
		Task WebSocket_OnSleep();
	}
}