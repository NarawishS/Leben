using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class ProbabilityManager : MonoBehaviour
    {
        public static bool ProbabilityCheckByPercent(int percentProbability)
        {
            float rnd = Random.Range(1, 101);
            return rnd <= percentProbability;
        }
    }
}