using UnityEngine;

namespace Script.Locations
{
    public class University : MonoBehaviour
    {
        public Timer timer;
        
        public AudioSource coinSFX;
        public AudioSource actionFailSFX;

        public void SelfStudy()
        {
            const int price = 0;
            const int health = 0;
            const int happy = 0;
            const int exp = 0;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(-happy);
                player.SetEducation(+exp);

                GameManager.Instance.ShowFloatingText($"{player.name}: Self Study");
                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void Classroom()
        {
            const int price = 0;
            const int health = 0;
            const int happy = 0;
            const int exp = 0;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(-health);
                player.SetHealth(-happy);
                player.SetEducation(+exp);

                GameManager.Instance.ShowFloatingText($"{player.name}: Classroom");
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

            if (player.GetJob() == Job.University)
            {
                coinSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.name}: work at {Job.University}");

                player.SetWealth(50);
                player.SetWorkExp(10);
                player.SetBurnOut(15);

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