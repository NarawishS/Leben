using UnityEngine;

namespace Script.Locations
{
    public class Mall : MonoBehaviour
    {
        public Timer timer;

        public AudioSource coinSFX;
        public AudioSource actionFailSFX;

        public void BuyCloth()
        {
            const int price = 300;
            var happy = Mathf.CeilToInt(price / 10f);

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(+happy);

                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Buy Cloth");
                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void WatchMovie()
        {
            const int price = 150;
            var happy = Mathf.CeilToInt(price / 10f);

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(+happy);

                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Watch Movie");
                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void BuyFurniture()
        {
            const int price = 1000;
            var happy = Mathf.CeilToInt(price / 10f);

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(+happy);

                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Buy Furniture");
                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void BuyToy()
        {
            const int price = 500;
            var happy = Mathf.CeilToInt(price / 10f);

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(+happy);

                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Buy Toy");
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