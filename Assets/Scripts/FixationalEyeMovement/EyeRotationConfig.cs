using System.Collections.Generic;
using FixationalEyeMovement.PseudoRandomWave;
using UnityEngine;

namespace FixationalEyeMovement
{

    [CreateAssetMenu(menuName = "FixationalEyeMovement/EyeRotationConfig")]
    public class EyeRotationConfig : ScriptableObject
    {

        public RandomWaveConfig Tremore;

        public RandomWaveConfig Drift;

        public RandomWaveConfig Flick;

        public IEnumerable<RandomCompositeWave> CreateWaves()
        {
            var tremore = new RandomCompositeWave(Tremore);
            var drift = new RandomCompositeWave(Drift);
            var flick = new RandomCompositeWave(Flick);

            return new[]
            {
                tremore,
                drift,
                flick
            };
        }

    }

}
