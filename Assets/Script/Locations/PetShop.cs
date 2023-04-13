using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Locations
{
    public class PetShop : MonoBehaviour
    {
        public Timer timer;
        public Button buyCatBtn;

        public void Update()
        {
            var player = GameManager.Instance.GetPlayer();

            buyCatBtn.interactable = !player.GetCat();
        }

        public void BuyCat()
        {
            const int price = 0;
            const int happy = 0;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(+happy);
                player.SetCat(true);

                GameManager.Instance.ShowFloatingText($"{player.name}: Buy Cat");
                timer.DecreaseTime(2);
            }
            else
            {
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void BuyCatFood()
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
                player.SetCatEat(true);

                GameManager.Instance.ShowFloatingText($"{player.name}: Buy Cat Food");
                timer.DecreaseTime(2);
            }
            else
            {
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
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);

                GameManager.Instance.ShowFloatingText($"{player.name}: Buy Cat Toy");
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

            if (player.GetJob() == Job.PetShop)
            {
                GameManager.Instance.ShowFloatingText($"{player.name}: work at {Job.PetShop}");

                player.SetWealth(50);
                player.SetWorkExp(10);
                player.SetBurnOut(15);

                timer.DecreaseTime(2);
            }
            else
            {
                GameManager.Instance.ShowFloatingText($"{player.name}: You did not apply for {Job.PetShop}");
            }
        }
    }
}