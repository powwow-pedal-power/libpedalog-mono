/* Pedalog.cs
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
using System.Text;
using System.Runtime.InteropServices;

namespace Pwpp.Pedalog
{
	/// <summary>
	/// A class that uses P/Invoke to call functions in libpedalog. 
	/// </summary>
    internal static class Pedalog
    {
        [DllImport("libpedalog.dll", EntryPoint = "pedalog_init", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Init();

        [DllImport("libpedalog.dll", EntryPoint = "pedalog_get_max_devices", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetMaxDevices();

        [DllImport("libpedalog.dll", EntryPoint = "pedalog_get_max_error_message", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetMaxErrorMessage();

        [DllImport("libpedalog.dll", EntryPoint = "pedalog_find_devices", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int FindDevices(Device[] devices);

        [DllImport("libpedalog.dll", EntryPoint = "pedalog_read_data", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ReadData(ref Device device, ref Data data);

        [DllImport("libpedalog.dll", EntryPoint = "pedalog_get_error_message", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void GetErrorMessage(int error, StringBuilder message);
    }
}
