using UnityEngine;

namespace FixationalEyeMovement
{

    public class FixationalEyeTransformation
    {

        const float TransitionSeconds = 1f;

        FixationalEyeRotation _main;

        float _rate;

        float _startedAt;

        FixationalEyeRotation _sub;

        public void Transit(FixationalEyeRotation newOne)
        {
            if (newOne == _main)
            {
                return;
            }
            
            _rate = 0f;
            _sub = _main;
            _main = newOne;
            _startedAt = Time.time;
        }

        public float? GetCurrentRotation()
        {
            if (_main == null)
            {
                return null;
            }

            if (_sub == null)
            {
                return _main.GetCurrentRotation();
            }

            if (_rate >= 1f)
            {
                return _main.GetCurrentRotation();
            }

            var main = _main.GetCurrentRotation();
            var sub = _sub.GetCurrentRotation();
            var current = Mathf.Lerp(sub, main, _rate);

            return current;
        }

        public void Update(float deltaTime)
        {
            _main?.Update(deltaTime);
            _sub?.Update(deltaTime);

            _rate = Mathf.Clamp01(
                _rate + deltaTime / TransitionSeconds
            );
        }

    }

}
