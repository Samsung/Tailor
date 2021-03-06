﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.Sensor;

namespace Param_RootNamespace.Services
{
    // For more information about sensors see https://docs.tizen.org/application/dotnet/guides/location-sensors/device-sensors
    public class AccelerometerService : IDisposable
    {
        private Accelerometer _sensor;

        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccelerometerService"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">The device does not support the sensor.</exception>
        /// <exception cref="UnauthorizedAccessException">The user does not grant your app access to sensors.</exception>
        public AccelerometerService()
        {
            try
            {
                // A NotSupportedException will be thrown if the sensor is not available on the device
                _sensor = new Accelerometer();

                // Add an event handler to the sensor
                _sensor.DataUpdated += OnSensorDataUpdated;

                // TODO: Declare how the sensor behaves when the screen turns off or the device goes into power save mode
                // For details see https://docs.tizen.org/application/dotnet/guides/location-sensors/device-sensors
                // _sensor.PausePolicy = SensorPausePolicy.All;

                // TODO: Set the update interval in milliseconds
                // _sensor.Interval = 1000;
            }
            catch (NotSupportedException)
            {
                // TODO: The device does not support the sensor, handle exception as appropriate to your scenario
            }
            catch (UnauthorizedAccessException)
            {
                // TODO: The user does not grant your app access to sensors, handle exception as appropriate to your scenario
            }
        }

        ~AccelerometerService()
        {
            Dispose(false);
        }

        /// <summary>
        /// Starts the sensor to receive sensor data.
        /// </summary>
        public void Start()
        {
            _sensor.Start();
        }

        /// <summary>
        /// Stops receiving sensor data.
        /// </summary>
        /// <remarks>
        /// Reduce battery drain by stopping the sensor when it is not needed.
        /// </remarks>
        public void Stop()
        {
            _sensor.Stop();
        }

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        /// <param name="disposing">Indicates whether the method call comes from a Dispose method or from a finalizer.</param>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _sensor.DataUpdated -= OnSensorDataUpdated;
                    _sensor.Dispose();
                }

                _sensor = null;
                _disposed = true;
            }
        }

        /// <summary>
        /// Called when the pedometer reports a new number of steps taken.
        /// </summary>
        private void OnSensorDataUpdated(object sender, AccelerometerDataUpdatedEventArgs e)
        {
            // TODO: Handle sensor data
            // More details at https://docs.tizen.org/application/dotnet/guides/location-sensors/device-sensors#accelerometer
            Logger.Info($"Accelerometer: {e.X}, {e.Y}, {e.Z}");
        }
    }
}
