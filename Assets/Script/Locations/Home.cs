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
            Player player = GameManager.Instance.GetPlayer();
            player.SetSleep(true);
            timer.ResetTime();
        }
    }
}