using UnityEngine;


namespace Script.Locations
{
    public class JobOffice : MonoBehaviour
    {
        public Timer timer;
        
        public AudioSource clickSFX;
        public AudioSource actionFailSFX;

        public void ApplyBank()
        {
            ApplyJob(Job.Bank);
        }

        public void ApplyCasino()
        {
            ApplyJob(Job.Casino);
        }

        public void ApplyGym()
        {
            ApplyJob(Job.Gym);
        }

        public void ApplyFastFood()
        {
            ApplyJob(Job.FastFood);
        }

        public void ApplyHospital()
        {
            ApplyJob(Job.Hospital);
        }

        public void ApplyMall()
        {
            ApplyJob(Job.Mall);
        }

        public void ApplyMarket()
        {
            ApplyJob(Job.Market);
        }

        public void ApplyPetShop()
        {
            ApplyJob(Job.PetShop);
        }

        public void ApplyUniversity()
        {
            ApplyJob(Job.University);
        }

        public void ApplyVehicle()
        {
            ApplyJob(Job.Vehicle);
        }

        public void ApplyJob(Job jobName)
        {
            var player = GameManager.Instance.GetPlayer();

            if (player.GetJob() != jobName)
            {
                clickSFX.Play();
                player.SetJob(jobName);

                GameManager.Instance.ShowFloatingText($"{player.name}: apply job for  {jobName}");

                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.name} already apply this job!");
            }
        }
    }
}

