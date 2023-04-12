using UnityEngine;
using UnityEngine.UI;

namespace Script.Locations
{
    public class Bank : MonoBehaviour
    {
        public Timer timer;
        public InputField inputField;

        public void DepositMoney()
        {
            var player = GameManager.instance.GetPlayer();
            var amount = int.Parse(inputField.text);

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

        public void WithdrawMoney()
        {
            var player = GameManager.instance.GetPlayer();
            var amount = int.Parse(inputField.text);

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
            var player = GameManager.instance.GetPlayer();
            
            if (player.GetJob() == Job.Bank)
            {
                Debug.Log($"{player.name}: work at {Job.Bank}");

                player.SetWealth(50);
                player.SetWorkExp(10);
                player.SetBurnOut(15);

                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log($"{player.name}: You did not apply for {Job.Bank}");
            }
        }
    }
}