using System.Reflection;
using System.Runtime.InteropServices;
using Android.App;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("LiLo.Lite.Android")]
[assembly: AssemblyDescription("LiLo.Lite is a light-weight cryptocurrency (crypto) price tracking application. It provides a quick and easy way to watch the top crypto currency information and charts. With extremely low battery usage, you can leave the application running in the background and have crypto information available right at your fingertips.")]
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
[assembly: AssemblyVersion("2.0.0.0")]
[assembly: AssemblyFileVersion("2.0.0.0")]

// Add some common permissions, these can be removed if not needed
[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]