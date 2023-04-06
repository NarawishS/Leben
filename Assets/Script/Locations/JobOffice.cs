using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Script.Locations
{
    public class JobOffice : MonoBehaviour
    {
        public Timer timer;

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

        private void ApplyJob(Job jobName)
        {
            Player player = GameManager.Instance.GetPlayer();

            player.SetJob(jobName);

            Debug.Log($"{player.name}: apply job for  {jobName}");

            timer.DecreaseTime(2);
        }
    }
}

public enum Job
{
    None,
    Bank,
    Casino,
    FastFood,
    Gym,
    Hospital,
    Mall,
    Market,
    PetShop,
    University,
    Vehicle
}