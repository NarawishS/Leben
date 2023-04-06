using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Script.Locations
{
    public class Home : MonoBehaviour
    {
        public Timer timer;

        public void EndTurn()
        {
            timer.ResetTime();
        }
    }
}