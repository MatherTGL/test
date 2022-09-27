using UnityEngine;

namespace Services
{
    public sealed class TimeAccelerationService : MonoBehaviour
    {
        private enum Acceleration { Pause = 0, Default = 1, X2 = 2, X4 = 4 }
        private static Acceleration _acceleration = Acceleration.Default;


        public static int UseAcceleration() { return (int)_acceleration; }

        private void Update() => CheckChangeAcceleration();

        private void CheckChangeAcceleration()
        {
            if (InputService.AxisKeySpace != 0.0f)
            {
                if (_acceleration == Acceleration.Pause)
                    _acceleration = Acceleration.Default;
                else
                    _acceleration = Acceleration.Pause;
            }

            if (InputService.AxisKeyNumberFirst != 0.0f)
                _acceleration = Acceleration.Default;

            if (InputService.AxisKeyNumberSecond != 0.0f)
                _acceleration = Acceleration.X2;

            if (InputService.AxisKeyNumberThird != 0.0f)
                _acceleration = Acceleration.X4;
        }
    }
}