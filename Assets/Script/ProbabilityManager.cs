using UnityEngine;

namespace Script
{
    public class ProbabilityManager : MonoBehaviour
    {
        public static bool ProbabilityCheckByPercent(int percentProbability)
        {
            var rnd = Random.Range(1, 101);
            return rnd <= percentProbability;
        }
    }
}