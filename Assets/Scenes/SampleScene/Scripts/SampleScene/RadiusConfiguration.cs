using UnityEngine;
using UnityEngine.Assertions;

namespace SampleScene
{


    public class RadiusConfiguration : MonoBehaviour
    {

        public GameObject EyeIn;

        public float Radius;

        // Start is called before the first frame update
        void Start()
        {
            Assert.IsNotNull(EyeIn);
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(0f, 0f, Radius);
            EyeIn.transform.localPosition = new Vector3(0f, 0f, -Radius);
        }

    }

}
