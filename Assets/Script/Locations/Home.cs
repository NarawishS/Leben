using UnityEngine;

namespace Script.Locations
{
    public class Home : MonoBehaviour
    {
        public Timer timer;
        
        public AudioSource clickSFX;

        public void EndTurn()
        {
            clickSFX.Play();
            var player = GameManager.Instance.GetPlayer();
            player.SetSleep(true);
            player.SetHappy(+(Mathf.FloorToInt(timer.GetTime() / 2) * 20));
            timer.ResetTime();
        }
    }
}