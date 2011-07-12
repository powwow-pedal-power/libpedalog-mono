/* Device.cs
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
    /// A struct that represents a connected Pedalog device.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Device
    {
        public int Serial;

        /// <summary>
        /// Static constructor that initialises the libpedalog library.
        /// </summary>
        static Device()
        {
            Pedalog.Init();
        }

        /// <summary>
        /// Finds all the connected Pedalog devices.
        /// </summary>
        /// <returns>
        /// A list of <see cref="Device[]"/> structs representing connected devices.
        /// </returns>
        public static Device[] FindAll()
        {
            int maxDevices = Pedalog.GetMaxDevices();

            Device[] devices = new Device[maxDevices];

            int deviceCount = Pedalog.FindDevices(devices);

            Device[] devicesToReturn = new Device[deviceCount];
            for (int i = 0; i < deviceCount; i++)
            {
                devicesToReturn[i] = devices[i];
            }

            return devicesToReturn;
        }

        /// <summary>
        /// Reads the current data values from a Pedalog device.
        /// </summary>
        /// <returns>
        /// A <see cref="Data"/> struct containing the device's current readings, or
        /// <c>null</c> if the device has been disconnected. If <c>null</c> is returned,
        /// <see cref="Device.FindAll"/> should be called again to re-enumerate the
        /// connected devices.
        /// </returns>
        public Data? ReadData()
        {
            Data data = new Data();

            var result = (Result)Pedalog.ReadData(ref this, ref data);
            if (result != Result.Ok)
            {
                if (result == Result.NoDeviceFound)
                {
                    return null;
                }

                throw PedalogException.CreateSpecificExceptionFromError(result);
            }

            return data;
        }
    }
}
