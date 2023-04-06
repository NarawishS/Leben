using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Script.Locations
{
    public class Hospital : MonoBehaviour
    {
        public Timer timer;

        public void DoPanel1()
        {
            const int price = 20;

            Player player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetMask(+1);
                Debug.Log($"{player.name}: Buy mask");
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void DoPanel2()
        {
            const int price = 200;

            Player player = GameManager.Instance.GetPlayer();
            
            if (player.GetWealth() >= price && player.GetInfectionStatus())
            {
                player.SetWealth(-price);
                player.SetInfectionStatus(false);
                
                Debug.Log($"{player.name}: Get vaccinate");
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

            if (player.GetJob() == Job.Hospital)
            {
                Debug.Log($"{player.name}: work at {Job.Hospital}");

                player.SetWealth(50);
                player.SetWorkExp(10);

                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log($"{player.name}: You did not apply for {Job.Hospital}");
            }
        }
    }
}