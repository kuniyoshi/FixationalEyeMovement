using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FixationalEyeMovement.PseudoRandomWave
{

    public class RandomCompositeWave
    {

        RandomWaveConfig Config { get; }

        List<RandomWaveValue> Waves { get; }

        public RandomCompositeWave(RandomWaveConfig randomWaveConfig)
        {
            Config = Object.Instantiate(randomWaveConfig);
            
            Waves = Config
                .RandomWaveParameters
                .Select(parameter => new RandomWaveValue(parameter))
                .ToList();
        }

        public float GetCurrent()
        {
            var value = Waves.Sum(wave => wave.GetCurrent());

            return value;
        }

        public void Update(float deltaTime)
        {
            Waves.ForEach(wave => wave.Update(deltaTime));
        }

    }

}
