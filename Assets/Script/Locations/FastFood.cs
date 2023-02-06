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
            Player player;
            int price = 65;
            int health = 20;
            int happy = 20;

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
            Player player;
            int price = 20;
            int health = 20;
            int happy = 10;

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
            Player player;
            int price = 40;
            int health = 20;
            int happy = 10;

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
            Player player;
            int price = 100;
            int health = 20;
            int happy = 10;

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
                
                Debug.Log($"{player.name}: buy chicked");
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
            
            if (player.GetJob() == "fastfood")
            {
                Debug.Log($"{player.name}: work at fastfood");
                
                player.SetWealth(50);
                player.SetWorkExp(10);
            
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log($"{player.name}: You did not apply for this Job");
            }
        }
    }
}