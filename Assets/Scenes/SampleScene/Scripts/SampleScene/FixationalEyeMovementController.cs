using FixationalEyeMovement;
using UnityEngine;
using UnityEngine.Assertions;

namespace SampleScene
{

    public class FixationalEyeMovementController : MonoBehaviour
    {

        public EyeRotationConfig EyeRotationConfig;

        Vector3 _initialRotation;

        FixationalEyeRotation _rotation;

        void Awake()
        {
            Assert.IsNotNull(EyeRotationConfig);
        }

        void Start()
        {
            _initialRotation = transform.rotation.eulerAngles;
            _rotation = new FixationalEyeRotation(EyeRotationConfig);
        }

        void Update()
        {
            _rotation.Update(Time.deltaTime);

            var y = _rotation.GetCurrentRotation();
            var rotation = new Vector3(0f, y, 0f);

            transform.rotation = Quaternion.Euler(
                _initialRotation + rotation
            );
        }

    }

}
