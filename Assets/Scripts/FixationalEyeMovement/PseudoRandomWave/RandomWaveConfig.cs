using System.Collections.Generic;
using UnityEngine;

namespace FixationalEyeMovement.PseudoRandomWave
{

    [CreateAssetMenu(menuName = "FixationalEyeMovement/PseudoRandomWave/RandomWaveConfig")]
    public class RandomWaveConfig : ScriptableObject
    {

        public List<RandomWaveParameter> RandomWaveParameters;

    }

}
