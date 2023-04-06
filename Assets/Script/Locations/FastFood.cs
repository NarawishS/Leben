using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Script.Locations
{
    public class FastFood : MonoBehaviour
    {
        public Timer timer;

        public void BuyBurger()
        {
            Player player = GameManager.Instance.GetPlayer();
            int price = 65;
            int health = 20;
            int happy = 20;
            int cal = 10;
            

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                player.SetSatiated(+cal);
                Debug.Log($"{player.name}: buy burger");
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void BuyCoke()
        {
            Player player = GameManager.Instance.GetPlayer();
            int price = 20;
            int health = 20;
            int happy = 10;
            int cal = 1;

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                player.SetSatiated(+cal);

                Debug.Log($"{player.name}: buy coke");
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void BuyFried()
        {
            Player player = GameManager.Instance.GetPlayer();
            int price = 40;
            int health = 20;
            int happy = 10;
            int cal = 5;

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                player.SetSatiated(+cal);

                Debug.Log($"{player.name}: buy fried");
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void BuyChicken()
        {
            Player player = GameManager.Instance.GetPlayer();
            int price = 100;
            int health = 20;
            int happy = 10;
            int cal = 20;

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                player.SetSatiated(+cal);

                Debug.Log($"{player.name}: buy chicken");
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void Work()
        {
            Player player = GameManager.Instance.GetPlayer();

            if (player.GetJob() == Job.FastFood)
            {
                Debug.Log($"{player.name}: work at {Job.FastFood}");

                player.SetWealth(50);
                player.SetWorkExp(10);

                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log($"{player.name}: You did not apply for {Job.FastFood}");
            }
        }
    }
}