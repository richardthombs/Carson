﻿using System;
using System.Collections.Generic;

using ZWave;
using ZWave.Channel;

namespace Experiment1
{
	class NodeState
	{
		public byte NodeID;
		public string Name;
		public string Alias;

		public bool Muted;
		public bool Failed;     // Controller thinks node has failed
		public bool Removed;    // No longer in the list reported by the controller

		public DateTimeOffset? FirstFailed;
		public DateTimeOffset? LastFailed;
		public int FailCount;

		public bool HasBattery;
		public DateTimeOffset? LastWakeUp;

		public DateTimeOffset? FirstContact;
		public DateTimeOffset? LastContact;

		public List<CommandClass> CommandClasses;
		public GenericType GenericType;

		public DateTimeOffset? FirstAdded;

		public Report<BatteryReport> BatteryReport;
		public Report<SensorMultiLevelReport> TemperatureReport;
		public Report<SensorMultiLevelReport> LuminanceReport;
		public Report<SensorMultiLevelReport> RelativeHumidityReport;
		public Report<AlarmReport> AlarmReport;
		public Report<ManufacturerSpecificReport> ManufacturerReport;

		public void RecordFailure()
		{
			if (FirstFailed == null) FirstFailed = DateTimeOffset.UtcNow;
			LastFailed = DateTimeOffset.UtcNow;
			FailCount++;
		}

		void ResetFailure()
		{
			LastFailed = FirstFailed = null;
			FailCount = 0;
		}

		public void RecordContact()
		{
			if (FirstContact == null) FirstContact = DateTimeOffset.UtcNow;
			LastContact = DateTimeOffset.UtcNow;

			ResetFailure();
		}
	}
}
