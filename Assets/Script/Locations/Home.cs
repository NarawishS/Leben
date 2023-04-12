using UnityEngine;

namespace Script.Locations
{
    public class Home : MonoBehaviour
    {
        public Timer timer;

        public void EndTurn()
        {
            var player = GameManager.instance.GetPlayer();
            player.SetSleep(true);
            player.SetHappy(+(Mathf.FloorToInt(timer.GetTime() / 2) * 20));
            timer.ResetTime();
        }
    }
}