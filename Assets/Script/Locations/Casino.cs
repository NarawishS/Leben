using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Locations
{
    public class Casino : MonoBehaviour
    {
        public Timer timer;
        public InputField inputField;

        public AudioSource coinSFX;
        public AudioSource actionFailSFX;

        public void Slot()
        {
            const float reward = 1.5f;
            var player = GameManager.Instance.GetPlayer();
            int price;
            
            try
            {
                price = int.Parse(inputField.text);
            }
            catch (Exception e)
            {
                GameManager.Instance.ShowFloatingText(e.Message);
                return;
            }
            price = int.Parse(inputField.text);
            
            const int health = 5;
            var happy = Mathf.CeilToInt(price / 100f * reward);

            if (price <= 0)
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("Invalid amount of money");
            }
            else if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(-health);

                if (ProbabilityManager.ProbabilityCheckByPercent(40))
                {
                    player.SetWealth(+Mathf.CeilToInt(price * reward));
                    player.SetHappy(+happy);
                    GameManager.Instance.ShowFloatingText($"{player.name}: WIN Slot {price * reward} G");
                }
                else
                {
                    GameManager.Instance.ShowFloatingText($"{player.name}: LOSE Slot -{price} G");
                    player.SetHappy(-happy);
                }

                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void Card()
        {
            const float reward = 2f;
            var player = GameManager.Instance.GetPlayer();
            const int health = 5;
            
            int price;
            
            try
            {
                price = int.Parse(inputField.text);
            }
            catch (Exception e)
            {
                GameManager.Instance.ShowFloatingText(e.Message);
                return;
            }
            price = int.Parse(inputField.text);
            var happy = Mathf.CeilToInt(price / 100f * reward);

            if (price <= 0)
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("Invalid amount of money");
            }
            else if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(-health);

                if (ProbabilityManager.ProbabilityCheckByPercent(35))
                {
                    player.SetWealth(+Mathf.CeilToInt(price * reward));
                    player.SetHappy(+happy);
                    GameManager.Instance.ShowFloatingText($"{player.name}: WIN Card {price * reward} G");
                }
                else
                {
                    GameManager.Instance.ShowFloatingText($"{player.name}: LOSE card -{price} G");
                    player.SetHappy(-happy);
                }

                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void Roulette()
        {
            const float reward = 3f;
            var player = GameManager.Instance.GetPlayer();
            const int health = 5;
            int price;
            
            try
            {
                price = int.Parse(inputField.text);
            }
            catch (Exception e)
            {
                GameManager.Instance.ShowFloatingText(e.Message);
                return;
            }
            price = int.Parse(inputField.text);
            var happy = Mathf.CeilToInt(price / 100f * reward);

            if (price <= 0)
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("Invalid amount of money");
            }
            else if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(-health);

                if (ProbabilityManager.ProbabilityCheckByPercent(30))
                {
                    player.SetWealth(+Mathf.CeilToInt(price * reward));
                    player.SetHappy(+happy);
                    GameManager.Instance.ShowFloatingText($"{player.name}: WIN Roulette {price * reward} G");
                }
                else
                {
                    GameManager.Instance.ShowFloatingText($"{player.name}: LOSE Roulette -{price} G");
                    player.SetHappy(-happy);
                }

                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void AllIn()
        {
            const float reward = 10f;
            var player = GameManager.Instance.GetPlayer();
            var price = player.GetWealth();
            const int health = 5;
            var happy = Mathf.CeilToInt(price / 100f * reward);

            if (player.GetWealth() > 0)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(-health);

                if (ProbabilityManager.ProbabilityCheckByPercent(5))
                {
                    player.SetWealth(+Mathf.CeilToInt(price * reward));
                    player.SetHappy(+happy);

                    GameManager.Instance.ShowFloatingText($"{player.name}: JACKPOT WIN {price * reward} G");
                }
                else
                {
                    GameManager.Instance.ShowFloatingText($"{player.name}: LOSE ALL IN -{price} G");
                    player.SetHappy(-happy);
                }

                timer.DecreaseTime(2);
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
            const int burnOut = 15;

            var salary = Mathf.CeilToInt(baseSalary * (1 + player.GetWorkExp() / 100f + player.GetEducation() / 100f));

            if (player.GetJob() == Job.University)
            {
                coinSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.name}: work at {Job.University}");

                player.SetWealth(+salary);
                player.SetWorkExp(+workExp);
                player.SetBurnOut(+burnOut);

                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.name}: You did not apply for {Job.University}");
            }
        }
    }
}