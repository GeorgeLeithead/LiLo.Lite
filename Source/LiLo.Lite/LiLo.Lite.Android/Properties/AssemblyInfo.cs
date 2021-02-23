using System.Reflection;
using System.Runtime.InteropServices;
using Android.App;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("LiLo.Lite.Android")]
[assembly: AssemblyDescription("LiLo 'lite' is a light-weight version of LiLo. The mobile application is written using Xamarin.Forms and integrates with the ByBit WebSockets service to provide live real-time market information, and using a WebView to display charting information from TradingView.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("InternetWideWorld.com")]
[assembly: AssemblyProduct("LiLo.Lite.Android")]
[assembly: AssemblyCopyright("Copyright ©  2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
[assembly: AssemblyVersion("1.0.5.0")]
[assembly: AssemblyFileVersion("1.0.5.0")]

// Add some common permissions, these can be removed if not needed
[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]
