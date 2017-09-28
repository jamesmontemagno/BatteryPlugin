## Battery Status Plugin for Xamarin and Windows

Simple cross platform plugin to check batterystatus of mobile device, get remaining percentage for Xamarin.iOS, Xamarin.Android, Windows, and Xamarin.Forms projects.

### Setup
* Available on NuGet: http://www.nuget.org/packages/Xam.Plugin.Battery  [![NuGet](https://img.shields.io/nuget/v/Xam.Plugin.Battery.svg?label=NuGet)](https://www.nuget.org/packages/Xam.Plugin.Battery/)
* Install into your PCL project and Client projects.

Build Status: 
* [![Build status](https://ci.appveyor.com/api/projects/status/k7cjo91oamdxt8bd?svg=true)](https://ci.appveyor.com/project/JamesMontemagno/batteryplugin)
* CI NuGet Feed: https://ci.appveyor.com/nuget/batteryplugin

**Platform Support**

|Platform|Version|
| -------------------  | :------------------: |
|Xamarin.iOS|iOS 6+|
|Xamarin.Android|API 10+|
|Windows 10 UWP|10+|


**Windows Store has a blank DLL that always returns 100, Ac, and Full as there is no API for checking battery**


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
