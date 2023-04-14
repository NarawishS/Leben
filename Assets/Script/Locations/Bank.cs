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
            var amount = int.Parse(inputField.text);

            if (!IsValidAmount(amount))
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("Invalid amount of money"); 
            }
            else if (player.GetWealth() >= amount)
            {
                coinSFX.Play();
                player.SetWealth(-amount);
                player.SetDepositMoney(+amount);
                GameManager.Instance.ShowFloatingText($"{player.name}: Deposit Money {amount}");
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
            var amount = int.Parse(inputField.text);

            if (!IsValidAmount(amount))
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("Invalid amount of money"); 
            }
            else if (player.GetDepositMoney() >= amount)
            {
                coinSFX.Play();
                player.SetWealth(+amount);
                player.SetDepositMoney(-amount);
                GameManager.Instance.ShowFloatingText($"{player.name}: Withdraw Money {amount}");
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

            if (player.GetJob() == Job.Bank)
            {
                coinSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.name}: work at {Job.Bank}");

                player.SetWealth(50);
                player.SetWorkExp(10);
                player.SetBurnOut(15);

                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.name}: You did not apply for {Job.Bank}");
            }
        }

        public bool IsValidAmount(int amount)
        {
            return amount > 0;
        }
    }
}