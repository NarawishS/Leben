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
            
            if (player.GetCat() && player.GetCatEat())
            {
                player.SetHappy(+Mathf.CeilToInt(timer.GetTime()));
            }
            else
            {
                player.SetHappy(+Mathf.CeilToInt(timer.GetTime() / 2));
            }

            timer.ResetTime();
        }
    }
}