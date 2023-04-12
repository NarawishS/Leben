using UnityEngine;

namespace Script.Locations
{
    public class FastFood : MonoBehaviour
    {
        public Timer timer;
        
        public void BuyBurger()
        {
            var player = GameManager.instance.GetPlayer();
            const int price = 65;
            const int health = 20;
            const int happy = 20;
            const int cal = 10;
            

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                player.SetSatiated(+cal);
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
            var player = GameManager.instance.GetPlayer();
            const int price = 20;
            const int health = 20;
            const int happy = 10;
            const int cal = 1;

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                player.SetSatiated(+cal);

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
            var player = GameManager.instance.GetPlayer();
            const int price = 40;
            const int health = 20;
            const int happy = 10;
            const int cal = 5;

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                player.SetSatiated(+cal);

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
            var player = GameManager.instance.GetPlayer();
            const int price = 100;
            const int health = 20;
            const int happy = 10;
            const int cal = 20;

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                player.SetSatiated(+cal);

                Debug.Log($"{player.name}: buy chicken");
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

            if (player.GetJob() == Job.FastFood)
            {
                Debug.Log($"{player.name}: work at {Job.FastFood}");

                player.SetWealth(50);
                player.SetWorkExp(10);
                player.SetBurnOut(15);

                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log($"{player.name}: You did not apply for {Job.FastFood}");
            }
        }
    }
}