using UnityEngine;

namespace Script.Locations
{
    public class FastFood : MonoBehaviour
    {
        public Timer timer;
        
        public AudioSource coinSFX;
        public AudioSource actionFailSFX;
        
        public void BuyBurger()
        {
            var player = GameManager.Instance.GetPlayer();
            const int price = 65;
            const int health = 20;
            const int happy = 20;
            const int cal = 10;
            

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                player.SetSatiated(+cal);
                GameManager.Instance.ShowFloatingText($"{player.name}: buy burger");
                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void BuyCoke()
        {
            var player = GameManager.Instance.GetPlayer();
            const int price = 20;
            const int health = 20;
            const int happy = 10;
            const int cal = 1;

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                player.SetSatiated(+cal);

                GameManager.Instance.ShowFloatingText($"{player.name}: buy coke");
                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void BuyFried()
        {
            var player = GameManager.Instance.GetPlayer();
            const int price = 40;
            const int health = 20;
            const int happy = 10;
            const int cal = 5;

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                player.SetSatiated(+cal);

                GameManager.Instance.ShowFloatingText($"{player.name}: buy fried");
                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void BuyChicken()
        {
            var player = GameManager.Instance.GetPlayer();
            const int price = 100;
            const int health = 20;
            const int happy = 10;
            const int cal = 20;

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                player.SetSatiated(+cal);

                GameManager.Instance.ShowFloatingText($"{player.name}: buy chicken");
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