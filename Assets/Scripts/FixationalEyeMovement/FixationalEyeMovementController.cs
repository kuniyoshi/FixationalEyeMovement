using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace FixationalEyeMovement
{

    public class FixationalEyeMovementController : MonoBehaviour
    {

        public EyeRotationConfig Tremore;

        public EyeRotationConfig Drift;

        public EyeRotationConfig Flick;

        Vector3 _initialRotation;

        List<FixationalEyeRotation> _rotations;

        void Awake()
        {
            Assert.IsNotNull(Tremore);
            Assert.IsNotNull(Drift);
            Assert.IsNotNull(Flick);
        }

        void Start()
        {
            _initialRotation = transform.rotation.eulerAngles;

            _rotations = new[] {Tremore, Drift, Flick}
                .Select(config =>
                {
                    var rotation = new FixationalEyeRotation();
                    rotation.Setup(config);

                    return rotation;
                })
                .ToList();
        }

        void Update()
        {
            _rotations.ForEach(r => r.Update(Time.deltaTime));

            var y = _rotations.Sum(r => r.GetCurrentRotation());

            var rotation = new Vector3(0f, y, 0f);

            transform.rotation = Quaternion.Euler(
                _initialRotation + rotation
            );
        }

    }

}
