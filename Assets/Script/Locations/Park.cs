using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Script.Locations
{
    public class Park : MonoBehaviour
    {
        public Timer timer;

        public void DoPanel1()
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
        
    }
}