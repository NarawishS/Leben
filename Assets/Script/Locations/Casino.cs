using UnityEngine;
using UnityEngine.UI;

namespace Script.Locations
{
    public class Casino : MonoBehaviour
    {
        public Timer timer;
        public InputField inputField;

        public void Slot()
        {
            const float reward = 1.5f;
            var player = GameManager.instance.GetPlayer();
            var price = int.Parse(inputField.text);
            const int health = 5;
            var happy = Mathf.FloorToInt(price / 100f * reward);

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);

                if (ProbabilityManager.ProbabilityCheckByPercent(40))
                {
                    player.SetWealth(+Mathf.FloorToInt(price * reward));
                    player.SetHappy(+happy);
                    Debug.Log($"{player.name}: WIN Slot {price * reward} G");
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

        public void Card()
        {
            const float reward = 2f;
            var player = GameManager.instance.GetPlayer();
            var price = int.Parse(inputField.text);
            const int health = 5;
            var happy = Mathf.FloorToInt(price / 100f * reward);

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);

                if (ProbabilityManager.ProbabilityCheckByPercent(35))
                {
                    player.SetWealth(+Mathf.FloorToInt(price * reward));
                    player.SetHappy(+happy);
                    Debug.Log($"{player.name}: WIN Card {price * reward} G");
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

        public void Roulette()
        {
            const float reward = 3f;
            var player = GameManager.instance.GetPlayer();
            var price = int.Parse(inputField.text);
            const int health = 5;
            var happy = Mathf.FloorToInt(price / 100f * reward);

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);

                if (ProbabilityManager.ProbabilityCheckByPercent(30))
                {
                    player.SetWealth(+Mathf.FloorToInt(price * reward));
                    player.SetHappy(+happy);
                    Debug.Log($"{player.name}: WIN Roulette {price * reward} G");
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

        public void AllIn()
        {
            const float reward = 10f;
            var player = GameManager.instance.GetPlayer();
            var price = player.GetWealth();
            const int health = 5;
            var happy = Mathf.FloorToInt(price / 100f * reward);

            if (player.GetWealth() > 0)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);

                if (ProbabilityManager.ProbabilityCheckByPercent(5))
                {
                    player.SetWealth(+Mathf.FloorToInt(price * reward));
                    player.SetHappy(+happy);

                    Debug.Log($"{player.name}: JACKPOT WIN {price * reward} G");
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
            var player = GameManager.instance.GetPlayer();

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