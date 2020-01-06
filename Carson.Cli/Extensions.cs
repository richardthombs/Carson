﻿using System;

namespace Experiment1
{
	static class Extensions
	{
		public static bool IsOlderThan(this DateTimeOffset timestamp, TimeSpan value)
		{
			return (DateTimeOffset.UtcNow - timestamp) > value;
		}

		public static bool IsOlderThan(this DateTimeOffset? timestamp, TimeSpan value)
		{
			if (!timestamp.HasValue) return true;

			return timestamp.Value.IsOlderThan(value);
		}

		public static string Ago(this DateTimeOffset timestamp)
		{
			var span = DateTimeOffset.Now - timestamp;

			if (span.Days >= 28) return timestamp.ToString("d");

			if (span.Days >= 7) return $"{dayPlural(span.Days)} ago";

			if (span.Days >= 1) return $"{dayPlural(span.Days)}, {hourPlural(span.Hours)} ago";

			if (span.Hours >= 1) return $"{hourPlural(span.Hours)}, {minutePlural(span.Minutes)} ago";

			if (span.Minutes >= 1) return $"{minutePlural(span.Minutes)} ago";

			return $"{secondPlural(span.Seconds)} ago";
		}

		public static string Ago(this DateTimeOffset? timestamp)
		{
			if (!timestamp.HasValue) return "never";
			return timestamp.Value.Ago();
		}

		static string dayPlural(int days)
		{
			return days == 1 ? "1 day" : $"{days} days";
		}

		static string hourPlural(int hours)
		{
			return hours == 1 ? "1 hour" : $"{hours} hours";
		}

		static string minutePlural(int minutes)
		{
			return minutes == 1 ? "1 minute" : $"{minutes} minutes";
		}

		static string secondPlural(int minutes)
		{
			return minutes == 1 ? "1 second" : $"{minutes} seconds";
		}
	}
}