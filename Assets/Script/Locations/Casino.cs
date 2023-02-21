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
            Player player;
            int price = 100;
            int health = 5;
            int happy = 5;

            if (GameManager.Instance.state == GameState.P1Turn)
            {
                player = GameManager.Instance.player1;
            }
            else
            {
                player = GameManager.Instance.player2;
            }

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);

                if (ProbabilityManager.ProbabilityCheckByPercent(50))
                {
                    player.SetWealth(+(price*2));
                    player.SetHappy(+happy);
                }
                else
                {
                    player.SetHappy(-happy);
                }
                
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
            Player player;
            int price = 0;
            int health = 0;
            int happy = 0;

            if (GameManager.Instance.state == GameState.P1Turn)
            {
                player = GameManager.Instance.player1;
            }
            else
            {
                player = GameManager.Instance.player2;
            }

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                
                Debug.Log($"{player.name}: Do Panel 2");
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }
        
        public void DoPanel3()
        {
            Player player;
            int price = 0;
            int health = 0;
            int happy = 0;

            if (GameManager.Instance.state == GameState.P1Turn)
            {
                player = GameManager.Instance.player1;
            }
            else
            {
                player = GameManager.Instance.player2;
            }

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                
                Debug.Log($"{player.name}: Do Panel 3");
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }
        
        public void DoPanel4()
        {
            Player player;
            int price = 0;
            int health = 0;
            int happy = 0;

            if (GameManager.Instance.state == GameState.P1Turn)
            {
                player = GameManager.Instance.player1;
            }
            else
            {
                player = GameManager.Instance.player2;
            }

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                
                Debug.Log($"{player.name}: Do Panel 4");
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void Work()
        {
            Player player;

            if (GameManager.Instance.state == GameState.P1Turn)
            {
                player = GameManager.Instance.player1;
            }
            else
            {
                player = GameManager.Instance.player2;
            }
            
            if (player.GetJob() == "casino")
            {
                Debug.Log($"{player.name}: work at casino");
                
                player.SetWealth(50);
                player.SetWorkExp(10);
            
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log($"{player.name}: You did not apply for casino");
            }
        }
    }
}