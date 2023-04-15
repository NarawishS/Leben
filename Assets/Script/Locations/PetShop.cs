using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Locations
{
    public class PetShop : MonoBehaviour
    {
        public Timer timer;
        public Button buyCatBtn;
        
        public AudioSource coinSFX;
        public AudioSource actionFailSFX;

        public void Update()
        {
            var player = GameManager.Instance.GetPlayer();

            buyCatBtn.interactable = !player.GetCat();
        }

        public void BuyCat()
        {
            const int price = 1000;
            const int happy = 0;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(+happy);
                player.SetCat(true);

                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Buy Cat");
                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void BuyCatFood()
        {
            const int price = 100;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetCatEat(true);

                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Buy Cat Food");
                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void BuyCatToy()
        {
            const int price = 0;
            const int health = 0;
            const int happy = 0;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);

                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Buy Cat Toy");
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
            const int burnOut = 10;

            var salary = Mathf.CeilToInt(baseSalary * (1 + player.GetWorkExp() / 100f + player.GetEducation() / 100f));

            if (player.GetJob() == Job.PetShop)
            {
                coinSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: work at {Job.PetShop}");

                player.SetWealth(+salary);
                player.SetWorkExp(+workExp);
                player.SetBurnOut(+burnOut);

                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: You did not apply for {Job.PetShop}");
            }
        }
    }
}