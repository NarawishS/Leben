using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Locations
{
    public class Bank : MonoBehaviour
    {
        public Timer timer;
        public InputField inputField;

        public AudioSource coinSFX;
        public AudioSource actionFailSFX;

        public void DepositMoney()
        {
            var player = GameManager.Instance.GetPlayer();
            int amount;

            try
            {
                amount = int.Parse(inputField.text);
            }
            catch (Exception e)
            {
                GameManager.Instance.ShowFloatingText(e.Message);
                return;
            }

            amount = int.Parse(inputField.text);

            if (amount <= 0)
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("Invalid amount of money");
            }
            else if (player.GetWealth() >= amount)
            {
                coinSFX.Play();
                player.SetWealth(-amount);
                player.SetDepositMoney(+amount);
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Deposit Money {amount}");
                timer.DecreaseTime(2);
                inputField.text = "0";
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void WithdrawMoney()
        {
            var player = GameManager.Instance.GetPlayer();
            int amount;

            try
            {
                amount = int.Parse(inputField.text);
            }
            catch (Exception e)
            {
                GameManager.Instance.ShowFloatingText(e.Message);
                return;
            }

            amount = int.Parse(inputField.text);

            if (amount <= 0)
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("Invalid amount of money");
            }
            else if (player.GetDepositMoney() >= amount)
            {
                coinSFX.Play();
                player.SetWealth(+amount);
                player.SetDepositMoney(-amount);
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Withdraw Money {amount}");
                timer.DecreaseTime(2);
                inputField.text = "0";
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void Work()
        {
            var player = GameManager.Instance.GetPlayer();

            const int baseSalary = 50;
            const int workExp = 1;
            const int burnOut = 10;

            var salary = Mathf.CeilToInt(baseSalary * (1 + player.GetWorkExp() / 100f + player.GetEducation() / 100f));

            if (player.GetJob() == Job.Bank)
            {
                coinSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: work at {Job.Bank}");

                player.SetWealth(+salary);
                player.SetWorkExp(+workExp);
                player.SetBurnOut(+burnOut);

                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: You did not apply for {Job.Bank}");
            }
        }
    }
}