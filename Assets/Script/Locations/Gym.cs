using UnityEngine;

namespace Script.Locations
{
    public class Gym : MonoBehaviour
    {
        public Timer timer;

        public void BuyProtein()
        {
            const int price = 0;
            const int health = 5;
            const int happy = 0;
            const int cal = 5;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(+health);
                player.SetHealth(+happy);
                player.SetSatiated(+cal);

                GameManager.Instance.ShowFloatingText($"{player.name}: Drink Protein Shake");
                timer.DecreaseTime(2);
            }
            else
            {
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void DoWeightTrain()
        {
            const int price = 0;
            const int health = 20;
            const int happy = 0;
            const int stamina = 20;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(+health);
                player.SetHealth(+happy);
                player.SetStamina(-stamina);

                GameManager.Instance.ShowFloatingText($"{player.name}: Weight train");
                timer.DecreaseTime(2);
            }
            else
            {
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void DoTrainer()
        {
            const int price = 0;
            const int health = 50;
            const int happy = 0;
            const int stamina = 90;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                player.SetStamina(-stamina);

                GameManager.Instance.ShowFloatingText($"{player.name}: Trainer train");
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

            if (player.GetJob() == Job.Gym)
            {
                GameManager.Instance.ShowFloatingText($"{player.name}: work at {Job.Gym}");

                player.SetWealth(50);
                player.SetWorkExp(10);
                player.SetBurnOut(15);

                timer.DecreaseTime(2);
            }
            else
            {
                GameManager.Instance.ShowFloatingText($"{player.name}: You did not apply for {Job.Gym}");
            }
        }
    }
}