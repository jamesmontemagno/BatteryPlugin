using Plugin.Battery.Abstractions;
using Tizen.System;

namespace Plugin.Battery
{
	/// <summary>
	/// Implementation for Feature
	/// </summary>
	public class BatteryImplementation : BaseBatteryImplementation
	{
		/// <summary>
		/// Default constructor
		/// </summary>
		public BatteryImplementation()
		{
			Tizen.System.Battery.PercentChanged += BatteryPercentChanged;
			Tizen.System.Battery.LevelChanged += BatteryLevelChanged;
			Tizen.System.Battery.ChargingStateChanged += BatteryChargingStateChanged;
		}

		/// <summary>
		/// Get the current battery level
		/// </summary>
		public override int RemainingChargePercent
		{
			get
			{
				return Tizen.System.Battery.Percent;
			}
		}

		/// <summary>
		/// Get Current battery status
		/// </summary>
		public override BatteryStatus Status
		{
			get
			{
				if (RemainingChargePercent >= 100 || Tizen.System.Battery.Level == BatteryLevelStatus.Full)
					return Abstractions.BatteryStatus.Full;
				else if (RemainingChargePercent == 0)
					return Abstractions.BatteryStatus.Discharging;
				else if (RemainingChargePercent < 0)
					return Abstractions.BatteryStatus.Unknown;

				if (Tizen.System.Battery.IsCharging)
					return Abstractions.BatteryStatus.Charging;
				else
					return Abstractions.BatteryStatus.NotCharging;
			}
		}

		/// <summary>
		/// Get current power source of device
		/// </summary>
		public override PowerSource PowerSource
		{
			get
			{
				if (Status == BatteryStatus.Full || Status == BatteryStatus.Charging)
					return Abstractions.PowerSource.Ac;

				return Abstractions.PowerSource.Battery;
			}
		}

		private bool disposed = false;

		/// <summary>
		/// Dispose
		/// </summary>
		/// <param name="disposing"></param>
		public override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					Tizen.System.Battery.PercentChanged -= BatteryPercentChanged;
					Tizen.System.Battery.LevelChanged -= BatteryLevelChanged;
					Tizen.System.Battery.ChargingStateChanged -= BatteryChargingStateChanged;
				}

				disposed = true;
			}

			base.Dispose(disposing);
		}

		void BatteryPercentChanged(object sender, BatteryPercentChangedEventArgs args)
		{
			OnBatteryChanged(new BatteryChangedEventArgs
			{
				RemainingChargePercent = RemainingChargePercent,
				IsLow = RemainingChargePercent <= 15,
				PowerSource = PowerSource,
				Status = Status
			});
		}

		void BatteryLevelChanged(object sender, BatteryLevelChangedEventArgs args)
		{
			OnBatteryChanged(new BatteryChangedEventArgs
			{
				RemainingChargePercent = RemainingChargePercent,
				IsLow = RemainingChargePercent <= 15,
				PowerSource = PowerSource,
				Status = Status
			});
		}
		void BatteryChargingStateChanged(object sender, BatteryChargingStateChangedEventArgs args)
		{
			OnBatteryChanged(new BatteryChangedEventArgs
			{
				RemainingChargePercent = RemainingChargePercent,
				IsLow = RemainingChargePercent <= 15,
				PowerSource = PowerSource,
				Status = Status
			});
		}		
	}
}
