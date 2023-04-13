using UnityEngine;

namespace Script.Locations
{
    public class Market : MonoBehaviour
    {
        public Timer timer;

        public void BuyFreshFood()
        {
            const int price = 0;
            const int health = 0;
            const int happy = 0;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);

                GameManager.Instance.ShowFloatingText($"{player.name}: Buy Fresh Food");
                timer.DecreaseTime(2);
            }
            else
            {
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void Work()
        {
            var player = GameManager.Instance.GetPlayer();

            if (player.GetJob() == Job.Market)
            {
                GameManager.Instance.ShowFloatingText($"{player.name}: work at {Job.Market}");

                player.SetWealth(50);
                player.SetWorkExp(10);
                player.SetBurnOut(15);

                timer.DecreaseTime(2);
            }
            else
            {
                GameManager.Instance.ShowFloatingText($"{player.name}: You did not apply for {Job.Market}");
            }
        }
    }
}