using System;
using UnityEngine;
using Random = System.Random;

namespace FixationalEyeMovement.PseudoRandomWave
{

    /// <summary>
    /// </summary>
    /// <para>Box-Mullar's Method</para>
    public class NormalDistributionRandom
    {

        const float TwoPi = 2f * (float) Math.PI;

        Random X { get; }

        Random Y { get; }

        float? _next;

        public NormalDistributionRandom(int seed1, int seed2)
        {
            X = new Random(seed1);
            Y = new Random(seed2);
        }

        public float GetNext(float mean = 0f, float sd = 1f)
        {
            if (_next != null)
            {
                var next = mean + sd * _next.Value;
                _next = null;

                return next;
            }

            var x = (float)X.NextDouble();
            var y = (float)Y.NextDouble();

            var sqrt2LogX = Mathf.Sqrt(-2f * Mathf.Log(x));

            var z1 = sqrt2LogX * Mathf.Cos(TwoPi * y);
            var z2 = sqrt2LogX * Mathf.Sin(TwoPi * x);

            _next = z2;

            var value = mean + sd * z1;

            return value;
        }

    }

}
