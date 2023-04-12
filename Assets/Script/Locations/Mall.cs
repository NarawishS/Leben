using UnityEngine;

namespace Script.Locations
{
    public class Mall : MonoBehaviour
    {
        public Timer timer;

        public void BuyCloth()
        {
            const int price = 0;
            const int health = 0;
            const int happy = 0;

            var player = GameManager.instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                
                Debug.Log($"{player.name}: Buy Cloth");
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void WatchMovie()
        {
            const int price = 0;
            const int health = 0;
            const int happy = 0;

            var player = GameManager.instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                
                Debug.Log($"{player.name}: Watch Movie");
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }
        
        public void BuyFurniture()
        {
            const int price = 0;
            const int health = 0;
            const int happy = 0;

            var player = GameManager.instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                
                Debug.Log($"{player.name}: Buy Furniture");
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }
        
        public void BuyToy()
        {
            const int price = 0;
            const int health = 0;
            const int happy = 0;

            var player = GameManager.instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(+happy);
                
                Debug.Log($"{player.name}: Buy Toy");
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
            
            if (player.GetJob() == Job.Mall)
            {
                Debug.Log($"{player.name}: work at {Job.Mall}");
                
                player.SetWealth(50);
                player.SetWorkExp(10);
                player.SetBurnOut(15);
            
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log($"{player.name}: You did not apply for {Job.Mall}");
            }
        }
    }
}