using UnityEngine;

namespace DefaultNamespace
{

    public class TestSin : MonoBehaviour
    {

        public float Radius;

        public float Cycle;

        void Update()
        {
            var x = Radius * Mathf.Cos(Cycle * 2f * Mathf.PI * Time.time);
            var y = Radius * Mathf.Sin(Cycle * 2f * Mathf.PI * Time.time);

            transform.position = new Vector3(
                x, y, 0f
            );
        }

    }

}
