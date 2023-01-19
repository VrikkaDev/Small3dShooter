using UnityEngine;

namespace Settings
{
    public class Sensitivity
    {
        public static RangeAttribute SensitivityRange = new RangeAttribute(0.1f, 2.0f);
        public static RangeAttribute AccelerationRange = new RangeAttribute(1f, 50f);

        public static bool IsValidSensitivity(float value)
        {
            return value > SensitivityRange.min && value < SensitivityRange.max;
        }
        public static bool IsValidAcceleration(float value)
        {
            return value > AccelerationRange.min && value < AccelerationRange.max;
        }
        public Vector2 Value { get; set; } = new Vector2(0.5f, 0.15f);
        public Vector2 Acceleration { get; set; } = new Vector2(1f, 1f);
    }
}