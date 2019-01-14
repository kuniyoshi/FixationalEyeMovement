using UnityEngine;

namespace FixationalEyeMovement
{

    public class FixationalEyeRotation
    {

        const int DegreeSecondsToDegree = 3600;

        Vector3 _currentRotation;

        readonly Direction _direction;

        float _halfDegreeSeconds;

        float _hertz;

        float _normalizedPosition;

        public FixationalEyeRotation()
        {
            _direction = new Direction();
        }

        public float GetCurrentRotation()
        {
            var degree = _halfDegreeSeconds
                         / DegreeSecondsToDegree
                         * (2f * _normalizedPosition - 1f);

            return degree;
        }

        public void Setup(EyeRotationConfig eyeRotationConfig)
        {
            _halfDegreeSeconds = eyeRotationConfig.DegreeSeconds / 2f;
            _hertz = eyeRotationConfig.Hertz;
        }

        public override string ToString()
        {
            return $"{nameof(FixationalEyeRotation)}{{"
                   + $"CurrentValue: {GetCurrentRotation()}"
                   + $", Position: {_normalizedPosition}"
                   + $"}}";
        }

        public void Update(float deltaTime)
        {
            _normalizedPosition = _normalizedPosition
                                  + _direction.Value * _hertz * deltaTime;

            var didOverlap = _normalizedPosition > 1f
                             || _normalizedPosition < 0f;

            _normalizedPosition = Mathf.Clamp01(_normalizedPosition);

            if (didOverlap)
            {
                _direction.ChangeDirection();
            }
        }

    }

}
