/* PedalogException.cs
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
using System.Runtime.Serialization;

namespace Pwpp.Pedalog
{
    public class PedalogException : Exception
    {
        public PedalogException()
            : base()
        {
        }

        public PedalogException(string message)
            : base(message)
        {
        }

        public PedalogException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public PedalogException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        internal PedalogException(Result error)
            : base(GetErrorMessage(error))
        {
        }

        private static string GetErrorMessage(Result error)
        {
            int maxErrorMessage = Pedalog.GetMaxErrorMessage();
            StringBuilder message = new StringBuilder(maxErrorMessage);

            Pedalog.GetErrorMessage((int)error, message);

            return message.ToString();
        }

        internal static PedalogException CreateSpecificExceptionFromError(Result error)
        {
            switch (error)
            {
                case Result.FailedToOpen:
                    return new FailedToOpenException();
                case Result.BadResponse:
                    return new BadResponseException();
                case Result.DeviceBusy:
                    return new DeviceBusyException();
                default:
                    return new PedalogException("Unknown error");
            }
        }
    }
}
