using UnityEngine;

namespace Script.Locations
{
    public class University : MonoBehaviour
    {
        public Timer timer;

        public void SelfStudy()
        {
            const int price = 0;
            const int health = 0;
            const int happy = 0;
            const int exp = 0;

            var player = GameManager.instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(-happy);
                player.SetEducation(+exp);

                Debug.Log($"{player.name}: Self Study");
                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void Classroom()
        {
            const int price = 0;
            const int health = 0;
            const int happy = 0;
            const int exp = 0;

            var player = GameManager.instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(-happy);
                player.SetEducation(+exp);

                Debug.Log($"{player.name}: Classroom");
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

            if (player.GetJob() == Job.University)
            {
                Debug.Log($"{player.name}: work at {Job.University}");

                player.SetWealth(50);
                player.SetWorkExp(10);
                player.SetBurnOut(15);

                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log($"{player.name}: You did not apply for {Job.University}");
            }
        }
    }
}