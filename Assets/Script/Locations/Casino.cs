using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Script.Locations
{
    public class Casino : MonoBehaviour
    {
        public Timer timer;

        public void DoPanel1()
        {
            Player player = GameManager.Instance.GetPlayer();
            int price = 100;
            int health = 5;
            int happy = 5;

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);

                if (ProbabilityManager.ProbabilityCheckByPercent(25))
                {
                    player.SetWealth(+(price*2));
                    player.SetHappy(+happy);
                    Debug.Log($"{player.name}: WIN Slot {price*2} G");
                }
                else
                {
                    Debug.Log($"{player.name}: LOSE Slot -{price} G");
                    player.SetHappy(-happy);
                }
                
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void DoPanel2()
        {
            Player player = GameManager.Instance.GetPlayer();
            int price = 200;
            int health = 5;
            int happy = 10;

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);

                if (ProbabilityManager.ProbabilityCheckByPercent(10))
                {
                    player.SetWealth(+(price*2));
                    player.SetHappy(+happy);
                    Debug.Log($"{player.name}: WIN Card {price*2} G");
                }
                else
                {
                    Debug.Log($"{player.name}: LOSE card -{price} G");
                    player.SetHappy(-happy);
                }
                
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }
        
        public void DoPanel3()
        {
            Player player = GameManager.Instance.GetPlayer();
            int price = 500;
            int health = 5;
            int happy = 25;

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);

                if (ProbabilityManager.ProbabilityCheckByPercent(5))
                {
                    player.SetWealth(+(price*2));
                    player.SetHappy(+happy);
                    Debug.Log($"{player.name}: WIN Roulette {price*2} G");
                }
                else
                {
                    Debug.Log($"{player.name}: LOSE Roulette -{price} G");
                    player.SetHappy(-happy);
                }
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }
        
        public void DoPanel4()
        {
            Player player = GameManager.Instance.GetPlayer();
            int price;
            int health = 5;
            int happy;

            price = player.GetWealth();
            happy = price/100*5;

            if (player.GetWealth() > 0)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);

                if (ProbabilityManager.ProbabilityCheckByPercent(1))
                {
                    player.SetWealth(+(price*3));
                    player.SetHappy(+happy);
                    
                    Debug.Log($"{player.name}: JACKPOT WIN {price*3} G");
                }
                else
                {
                    Debug.Log($"{player.name}: LOSE ALL IN -{price} G");
                    player.SetHappy(-happy);
                }
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

            if (player.GetJob() == Job.Casino)
            {
                Debug.Log($"{player.name}: work at {Job.Casino}");
                
                player.SetWealth(50);
                player.SetWorkExp(10);
                player.SetBurnOut(15);
            
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log($"{player.name}: You did not apply for {Job.Casino}");
            }
        }
    }
}