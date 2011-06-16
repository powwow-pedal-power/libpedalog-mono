/* Data.cs
 *
 * Copyright (c) 2011 Dan Haughey (http://www.powwow-pedal-power.org.uk)
 *
 * This file is part of libpedalog-mono.
 *
 * libpedalog-mono is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * libpedalog-mono is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with libpedalog-mono.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Runtime.InteropServices;

namespace Pwpp.Pedalog
{
	/// <summary>
	/// A struct to hold data from a Pedalog device.
	/// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Data
    {
        public double Voltage;
	    public double Current;
        public double Power;
        public double Energy;
        public double MaxPower;
        public double AvgPower;
        public int Time;

		public string ToReadableString()
		{
			return String.Format("voltage: {0}, current: {1}, power: {2}, energy: {3}, max_power: {4}, avg_power: {5}, time: {6}",
			                     this.Voltage, this.Current,
			                     this.Power, this.Energy,
			                     this.MaxPower, this.AvgPower,
			                     this.Time);
		}
	}
}