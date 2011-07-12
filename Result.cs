/* Result.cs
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

namespace Pwpp.Pedalog
{
    /// <summary>
    /// An enumeration to represent the result of a call to libpedalog.
    /// </summary>
    internal enum Result
    {
        /// <summary>
        /// The operation was carried out successfully.
        /// </summary>
        Ok = 0,

       /// <summary>
       /// An unknown error occurred.
       /// </summary>
       Unknown = 1,

       /// <summary>
       /// The specified Pedalog device was not connected.
       /// </summary>
       NoDeviceFound = 2,

       /// <summary>
       /// The specified Pedalog device could not be opened for communication.
       /// This may be a permissions issue.
       /// </summary>
       FailedToOpen = 3,

       /// <summary>
       /// A bad response was received from the Pedalog device. This may indicate
       /// a firmware incompatibility.
       /// </summary>
       BadResponse = 4,

       /// <summary>
       /// The Pedalog device was busy. It may be in use by another application.
       /// </summary>
       DeviceBusy = 5,

       /// <summary>
       /// An out of memory error was reported by the USB library.
       /// </summary>
       OutOfMemory = 6
    }
}
