using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Script.Locations
{
    public class University : MonoBehaviour
    {
        public Timer timer;

        public void DoPanel1()
        {
            const int price = 0;
            const int health = 0;
            const int happy = 0;
            const int exp = 0;

            Player player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(-happy);
                player.SetEducation(+exp);

                Debug.Log($"{player.name}: Do Panel 1");
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
            const int health = 0;
            const int happy = 0;
            const int exp = 0;

            Player player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(-happy);
                player.SetEducation(+exp);

                Debug.Log($"{player.name}: Do Panel 2");
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

            if (player.GetJob() == Job.University)
            {
                Debug.Log($"{player.name}: work at {Job.University}");

                player.SetWealth(50);
                player.SetWorkExp(10);

                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log($"{player.name}: You did not apply for {Job.University}");
            }
        }
    }
}