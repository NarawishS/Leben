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

            var player = GameManager.Instance.state.Equals(GameState.P1Turn)
                ? GameManager.Instance.player1
                : GameManager.Instance.player2;

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

            var player = GameManager.Instance.state.Equals(GameState.P1Turn)
                ? GameManager.Instance.player1
                : GameManager.Instance.player2;

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
            const int price = 0;
            const int health = 0;
            const int happy = 0;

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
            var player = GameManager.Instance.state.Equals(GameState.P1Turn)
                ? GameManager.Instance.player1
                : GameManager.Instance.player2;

            if (player.GetJob() == "hospital")
            {
                Debug.Log($"{player.name}: work at hospital");

                player.SetWealth(50);
                player.SetWorkExp(10);

                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log($"{player.name}: You did not apply for hospital");
            }
        }
    }
}