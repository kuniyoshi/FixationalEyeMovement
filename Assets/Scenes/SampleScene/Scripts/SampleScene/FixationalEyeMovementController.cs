using FixationalEyeMovement;
using UnityEngine;
using UnityEngine.Assertions;

namespace SampleScene
{

    public class FixationalEyeMovementController : MonoBehaviour
    {

        public EyeRotationConfig HorizontalEyeRotationConfig;

        public RangeFloat HorizontalInitialRandomRange;

        public EyeRotationConfig VerticalEyeRotationConfig;
        
        public RangeFloat VerticalInitialRandomRange;

        Vector3 _initialRotation;

        FixationalEyeRotation _horizontalRotation;
        
        FixationalEyeRotation _verticalRotation;

        void Awake()
        {
            Assert.IsNotNull(HorizontalEyeRotationConfig, "HorizontalEyeRotationConfig != null");
            Assert.IsNotNull(VerticalEyeRotationConfig, "VerticalEyeRotationConfig != null");
        }

        void Start()
        {
            _initialRotation = transform.rotation.eulerAngles;
            _horizontalRotation = new FixationalEyeRotation(HorizontalEyeRotationConfig);
            _verticalRotation = new FixationalEyeRotation(VerticalEyeRotationConfig);

            var horizontalRandomElapsedTime = Random.Range(
                HorizontalInitialRandomRange.Min,
                HorizontalInitialRandomRange.Max
            );
            var verticalRandomElapsedTime = Random.Range(
                VerticalInitialRandomRange.Min,
                VerticalInitialRandomRange.Max
            );
            
            _horizontalRotation.Update(horizontalRandomElapsedTime);
            _verticalRotation.Update(verticalRandomElapsedTime);
        }

        void Update()
        {
            _horizontalRotation.Update(Time.deltaTime);
            _verticalRotation.Update(Time.deltaTime);

            var x = _verticalRotation.GetCurrentRotation();
            var y = _horizontalRotation.GetCurrentRotation();
            var rotation = new Vector3(x, y, 0f);

            transform.rotation = Quaternion.Euler(
                _initialRotation + rotation
            );
        }

    }

}
