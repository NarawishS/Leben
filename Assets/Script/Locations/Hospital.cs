using UnityEngine;

namespace Script.Locations
{
    public class Hospital : MonoBehaviour
    {
        public Timer timer;
        
        public AudioSource coinSFX;
        public AudioSource actionFailSFX;

        public void BuyMask()
        {
            const int price = 20;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetMask() >= 5)
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("You can only store 5 masks!");
            }
            else if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetMask(+1);
                GameManager.Instance.ShowFloatingText($"{player.name}: Buy mask");
                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void BuyVaccine()
        {
            const int price = 200;

            var player = GameManager.Instance.GetPlayer();

            if (!player.GetInfectionStatus())
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("You are not infected!");
            }
            else if (player.GetWealth() >= price)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetInfectionStatus(false);
                
                GameManager.Instance.ShowFloatingText($"{player.name}: Get vaccinate");
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

            if (player.GetJob() == Job.Hospital)
            {
                coinSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.name}: work at {Job.Hospital}");

                player.SetWealth(50);
                player.SetWorkExp(10);
                player.SetBurnOut(15);

                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.name}: You did not apply for {Job.Hospital}");
            }
        }
    }
}