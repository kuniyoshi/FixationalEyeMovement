using UnityEngine;
using UnityEngine.Assertions;

namespace SampleScene
{


    public class EyeController : MonoBehaviour
    {

        const float DegreeSecondsToDegree = 60f / 60f;

        public GameObject EyeIn;

        public float Radius;

        public float DegreeSeconds;

        Vector3 _initialRotation;

        // Start is called before the first frame update
        void Start()
        {
            Assert.IsNotNull(EyeIn);
            _initialRotation = transform.rotation.eulerAngles;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(0f, 0f, Radius);
            EyeIn.transform.localPosition = new Vector3(0f, 0f, -Radius);

            var rotation = _initialRotation
                           + new Vector3(0f, DegreeSeconds / DegreeSecondsToDegree, 0f);

            transform.rotation = Quaternion.Euler(rotation);
        }

    }

}
