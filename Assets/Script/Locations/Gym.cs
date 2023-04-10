using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Script.Locations
{
    public class Gym : MonoBehaviour
    {
        public Timer timer;

        public void DoPanel1()
        {
            const int price = 0;
            const int health = 5;
            const int happy = 0;
            const int cal = 5;

            Player player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(+health);
                player.SetHealth(+happy);
                player.SetSatiated(+cal);

                Debug.Log($"{player.name}: Drink Protein Shake");
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void DoPanel2()
        {
            const int price = 0;
            const int health = 20;
            const int happy = 0;
            const int stamina = 20;

            Player player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(+health);
                player.SetHealth(+happy);
                player.SetStamina(-stamina);

                Debug.Log($"{player.name}: Weight train");
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void DoPanel3()
        {
            const int price = 0;
            const int health = 50;
            const int happy = 0;
            const int stamina = 90;

            Player player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                player.SetStamina(-stamina);

                Debug.Log($"{player.name}: Trainer train");
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

            if (player.GetJob() == Job.Gym)
            {
                Debug.Log($"{player.name}: work at {Job.Gym}");

                player.SetWealth(50);
                player.SetWorkExp(10);
                player.SetBurnOut(15);

                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log($"{player.name}: You did not apply for {Job.Gym}");
            }
        }
    }
}