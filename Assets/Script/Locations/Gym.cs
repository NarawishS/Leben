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
            const int price = 0;
            const int health = 5;
            const int happy = 0;
            const int cal = 5;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(+health);
                player.SetHealth(+happy);
                player.SetSatiated(+cal);

                GameManager.Instance.ShowFloatingText($"{player.name}: Drink Protein Shake");
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
            const int price = 0;
            const int health = 20;
            const int happy = 0;
            const int stamina = 20;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(+health);
                player.SetHealth(+happy);
                player.SetStamina(-stamina);

                GameManager.Instance.ShowFloatingText($"{player.name}: Weight train");
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
            const int price = 0;
            const int health = 50;
            const int happy = 0;
            const int stamina = 90;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                player.SetStamina(-stamina);

                GameManager.Instance.ShowFloatingText($"{player.name}: Trainer train");
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
                GameManager.Instance.ShowFloatingText($"{player.name}: work at {Job.University}");

                player.SetWealth(+salary);
                player.SetWorkExp(+workExp);
                player.SetBurnOut(+burnOut);

                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.name}: You did not apply for {Job.University}");
            }
        }
    }
}