using UnityEngine;

namespace FixationalEyeMovement.PseudoRandomWave
{

    public class RandomWaveValue
    {

        const float Pi2 = 2f * Mathf.PI;

        const int SeedMax = 10000;

        const int SeedMin = 0;

        RandomWaveParameter Parameter { get; }

        NormalDistributionRandom Random { get; }

        float _time;

        public RandomWaveValue(RandomWaveParameter randomWaveParameter)
        {
            Parameter = randomWaveParameter;
            Random = new NormalDistributionRandom(
                UnityEngine.Random.Range(SeedMin, SeedMax),
                UnityEngine.Random.Range(SeedMin, SeedMax)
            );
        }

        public void Update(float deltaTime)
        {
            _time = _time
                    + deltaTime
                    + deltaTime * Random.GetNext(
                        0f,
                        Parameter.MagicStandardDeviationToHertz
                        * Parameter.Hertz
                    );
        }

        public float GetCurrent()
        {
            var value = Parameter.Amplitude
                        * Mathf.Sin(
                            Pi2
                            * _time
                            * Parameter.Hertz
                            + Parameter.Phase
                        );

            return value;
        }

    }

}
