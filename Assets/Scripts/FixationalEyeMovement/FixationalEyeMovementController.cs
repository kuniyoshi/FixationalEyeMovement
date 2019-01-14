using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace FixationalEyeMovement
{

    public class FixationalEyeMovementController : MonoBehaviour
    {

        public EyeRotationConfig Tremore;

        public List<EyeRotationConfig> Flicks;

        List<FixationalEyeRotation> _flicks;

        Vector3 _initialRotation;

        FixationalEyeRotation _tremore;

        void Awake()
        {
            Assert.IsNotNull(Tremore);
            Assert.IsNotNull(Flicks);
        }

        void Start()
        {
            _tremore = new FixationalEyeRotation();
            _tremore.Setup(Tremore);
            _flicks = Flicks
                .Select(config =>
                    {
                        var flick = new FixationalEyeRotation();
                        flick.Setup(config);

                        return flick;
                    }
                )
                .ToList();

            _initialRotation = transform.rotation.eulerAngles;
        }

        void Update()
        {
            _tremore.Update(Time.deltaTime);
            var tremoreRotation = _tremore.GetCurrentRotation();

            var flickRotations = _flicks.Select(flick =>
            {
                flick.Update(Time.deltaTime);

                return flick.GetCurrentRotation();
            });

            var y = tremoreRotation + flickRotations.Sum();

            var rotation = new Vector3(0f, y, 0f);

            transform.rotation = Quaternion.Euler(
                _initialRotation + rotation
            );
        }

    }

}
