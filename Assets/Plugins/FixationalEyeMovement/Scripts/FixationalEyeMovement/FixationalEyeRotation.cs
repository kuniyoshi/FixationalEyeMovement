using System.Collections.Generic;
using System.Linq;
using FixationalEyeMovement.PseudoRandomWave;
using UnityEngine;

namespace FixationalEyeMovement
{

    public class FixationalEyeRotation
    {

        const int DegreeSecondsToDegree = 3600;

        EyeRotationConfig Config { get; }

        List<RandomCompositeWave> Waves { get; }

        public FixationalEyeRotation(EyeRotationConfig eyeRotationConfig)
        {
            Config = Object.Instantiate(eyeRotationConfig);
            Waves = Config.CreateWaves()
                .ToList();
        }

        public float GetCurrentRotation()
        {
            var degree = Waves.Sum(wave => wave.GetCurrent())
                         / DegreeSecondsToDegree;

            return degree;
        }

        public override string ToString()
        {
            return $"{nameof(FixationalEyeRotation)}{{"
                   + $"CurrentValue: {GetCurrentRotation()}"
                   + $", Config: {Config}"
                   + $", Waves: [{string.Join(", ", Waves)}]"
                   + $"}}";
        }

        public void Update(float deltaTime)
        {
            Waves.ForEach(wave => wave.Update(deltaTime));
        }

    }

}
