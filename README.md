![LiLo](Screenshots/launcher_foreground.png "LiLo.Lite - logo")

# LiLo.Lite 
Open source repository for the LiLo.Lite (Ladder In Ladder Out) Mobile Application.

## Overview
LiLo 'lite' is a light-weight version of [LiLo](https://georgeleithead.github.io/LiLo_Public/).
The mobile application is written using Xamarin.Forms and integrates with the [ByBit](https://www.bybit.com) WebSockets service to provide live real-time market information, and using a WebView to display charting information from [TradingView](https://uk.tradingview.com/).

### Application Features
- Live real-time market information.
- Price change highlighting.
- Market 24hr price highs and lows.
- 1hr and 24hr price percentage changes.
- 24hr trading volume.
- Real-time currency charting from [TradingView](https://uk.tradingview.com/).

### Code Features
- MVVM pattern (including view model locater).
- Dependency injection.
- WebSockets real-time information.
- Custom converters, behaviors, controls, view extensions and data templates.
- Pancake, CoverFlow and Web views
- Simplified grid row & column definitions
- Light & dark modes
- Shared Transitions

### Libraries used
- [Xamarin.Forms](https://github.com/xamarin/Xamarin.Forms)
- [Xamarin.Essentials](https://github.com/xamarin/Essentials)
- [ResizetizerNT](https://github.com/Redth/ResizetizerNT)
- [websocket-sharp](https://github.com/PingmanTools/websocket-sharp/)
- [System.Text.Json](https://github.com/dotnet/corefx)
- [Xamarin.Forms.PancakeView](https://github.com/sthewissen/Xamarin.Forms.PancakeView)
- [Xamarin.Plugin.SharedTransitions](https://github.com/jsuarezruiz/Xamarin.Plugin.SharedTransitions)

## Supported Platforms: Android, iOS

The LiLo.Lite mobile application is currently available for these platforms:

| Platform | Install | Build Status |
| -------- | ------- | ------------ |
| Android  | [Alpha](https://install.appcenter.ms/users/george-internetwideworld.com/apps/LiLo.Lite.Android/releases/) | [![Build status](https://build.appcenter.ms/v0.1/apps/4a6daf54-3a40-41b5-b2b2-11f740b0b3c7/branches/master/badge)](https://appcenter.ms)       |
| iOS      | Alpha^ | N/A       |

^Currently don't have a MAC available with a new-enough version of XCode to build iOS!

## Social
If you want to get in contact with us on social platforms, you can reach us on [![Twitter URL](https://img.shields.io/twitter/url/https/twitter.com/LiLoMobileApp.svg?style=social&label=Follow%20%40LiLoMobileApp)](https://twitter.com/LiLoMobileApp).  *No personal information* is collected by the application, as such we do not know who you are, so please get in touch and let us know what you think about LiLo.Lite.

## Reporting bugs
We use GitHub issues [![GitHub issues](https://img.shields.io/github/issues/GeorgeLeithead/LiLo.Lite)](https://github.com/GeorgeLeithead/LiLo.Lite/issues) to track issues.  Feedback with improvements and raising of issues will be highly appreciated and accepted.

## Screens
NOTE: All of the screen shots are subject to change as the application evolves.

### Markets view
<img alt="Home view - Light theme" src="Screenshots/10.png" width="240" /> <img alt="Home view - Dark theme" src="Screenshots/11.png" width="240" /> 

### Chart view
<img alt="Chart view - Light theme" src="Screenshots/20.png" width="240" /> <img alt="Chart view - Dark theme" src="Screenshots/21.png" width="240" />

## More information
- Source code: https://github.com/GeorgeLeithead/LiLo.Lite
- Author: [George Leithead](https://twitter.com/GeorgeLeithead/)