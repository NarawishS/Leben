using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Locations
{
    public class Bank : MonoBehaviour
    {
        public Timer timer;
        public InputField inputField;

        public void DoPanel1()
        {
            Player player;
            var amount = int.Parse(inputField.text);

            if (GameManager.Instance.state == GameState.P1Turn)
            {
                player = GameManager.Instance.player1;
            }
            else
            {
                player = GameManager.Instance.player2;
            }

            if (player.GetWealth() >= amount)
            {
                player.SetWealth(-amount);
                player.SetDepositMoney(+amount);
                Debug.Log($"{player.name}: Deposit Money {amount}");
                Debug.Log($"{player.name}: Bank Money {player.GetDepositMoney()}");
                timer.DecreaseTime(2);
                inputField.text = "0";
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void DoPanel2()
        {
            Player player;
            var amount = int.Parse(inputField.text);

            if (GameManager.Instance.state == GameState.P1Turn)
            {
                player = GameManager.Instance.player1;
            }
            else
            {
                player = GameManager.Instance.player2;
            }

            if (player.GetDepositMoney() >= amount)
            {
                player.SetWealth(+amount);
                player.SetDepositMoney(-amount);
                Debug.Log($"{player.name}: Withdraw Money {amount}");
                Debug.Log($"{player.name}: Bank Money {player.GetDepositMoney()}");
                timer.DecreaseTime(2);
                inputField.text = "0";
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

            if (player.GetJob() == Job.Bank)
            {
                Debug.Log($"{player.name}: work at {Job.Bank}");

                player.SetWealth(50);
                player.SetWorkExp(10);

                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log($"{player.name}: You did not apply for {Job.Bank}");
            }
        }
    }
}