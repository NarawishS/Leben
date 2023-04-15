using UnityEngine;

namespace Script.Locations
{
    public class Gym : MonoBehaviour
    {
        public Timer timer;

        public AudioSource coinSFX;
        public AudioSource actionFailSFX;

        public void BuyProtein()
        {
            const int price = 50;
            var health = Mathf.CeilToInt(price / 10f);

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(+health);

                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Drink Protein Shake");
                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void DoWeightTrain()
        {
            const int price = 100;
            var health = Mathf.CeilToInt(price / 10f);
            const int stamina = 20;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(+health);
                player.SetStamina(-stamina);

                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Weight train");
                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void DoTrainer()
        {
            const int price = 500;
            var health = Mathf.CeilToInt(price / 10f);
            const int stamina = 90;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetStamina(-stamina);

                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Trainer train");
                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void Work()
        {
            var player = GameManager.Instance.GetPlayer();

            const int baseSalary = 50;
            const int workExp = 1;
            const int burnOut = 15;

            var salary = Mathf.CeilToInt(baseSalary * (1 + player.GetWorkExp() / 100f + player.GetEducation() / 100f));

            if (player.GetJob() == Job.University)
            {
                coinSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: work at {Job.University}");

                player.SetWealth(+salary);
                player.SetWorkExp(+workExp);
                player.SetBurnOut(+burnOut);

                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: You did not apply for {Job.University}");
            }
        }
    }
}