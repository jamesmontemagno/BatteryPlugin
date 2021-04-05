## Battery Status Plugin for Xamarin and Windows

Simple cross platform plugin to check battery status of mobile device, get remaining percentage for Xamarin.iOS, Xamarin.Android, Windows, and Xamarin.Forms projects.

### Setup
* Available on NuGet: http://www.nuget.org/packages/Xam.Plugin.Battery  [![NuGet](https://img.shields.io/nuget/v/Xam.Plugin.Battery.svg?label=NuGet)](https://www.nuget.org/packages/Xam.Plugin.Battery/)
* Install into your PCL/NetStanadrd project and Client projects.

Build Status: 
* ![Build status](https://jamesmontemagno.visualstudio.com/_apis/public/build/definitions/6b79a378-ddd6-4e31-98ac-a12fcd68644c/12/badge)
* CI NuGet Feed: http://myget.org/F/xamarin-plugins

### The Future: [Xamarin.Essentials](https://docs.microsoft.com/xamarin/essentials/index?WT.mc_id=friends-0000-jamont)

I have been working on Plugins for Xamarin for a long time now. Through the years I have always wanted to create a single, optimized, and official package from the Xamarin team at Microsoft that could easily be consumed by any application. The time is now with [Xamarin.Essentials](https://docs.microsoft.com/xamarin/essentials/index?WT.mc_id=friends-0000-jamont), which offers over 50 cross-platform native APIs in a single optimized package. I worked on this new library with an amazing team of developers and I highly highly highly recommend you check it out.

I will continue to work and maintain my Plugins, but I do recommend you checkout Xamarin.Essentials to see if it is a great fit your app as it has been for all of mine!

## Platform Support

|Platform|Version|
| -------------------  | :------------------: |
|Xamarin.iOS|iOS 6+|
|Xamarin.Android|API 10+|
|Windows 10 UWP|10+|
|Tizen.NET|4.0+|


**Windows Store has a blank DLL that always returns 100, AC, and Full as there is no API for checking battery**


### API Usage

Call **CrossBattery.Current** from any project or PCL to gain access to APIs.


**RemainingChargePercent**
```csharp
/// <summary>
/// Current battery level 0 - 100
/// </summary>
int RemainingChargePercent { get; }
```

**Status**
```csharp
/// <summary>
/// Current status of the battery
/// </summary>
BatteryStatus Status { get; }
```

This returns an enum with the current status of the battery. If charging or not:

```csharp
/// <summary>
/// Current status of battery
/// </summary>
public enum BatteryStatus
{
  /// <summary>
  /// Plugged in and charging
  /// </summary>
  Charging,
  /// <summary>
  /// Battery is being drained currently
  /// </summary>
  Discharging,
  /// <summary>
  /// Battery is full completely
  /// </summary>
  Full,
  /// <summary>
  /// Not charging, but not discharging either
  /// </summary>
  NotCharging,
  /// <summary>
  /// Unknown or other status
  /// </summary>
  Unknown

}
```

Important:
* iOS: only returns Charging, Full, Discharging, and Unknown.


**PowerSource**
```csharp
/// <summary>
/// Currently how the battery is being charged.
/// </summary>
PowerSource PowerSource { get; }
```

Returns how the phone is being charged

#### Events

You can subscribe to BatteryChanged, which will return BatteryChangedEventArgs with all information you need.
This occurs when plugged, unplugged, or battery change.

```csharp
/// <summary>
/// Event handler when battery changes
/// </summary>
event BatteryChangedEventHandler BatteryChanged;
```


#### License
Under MIT, see LICENSE file.
