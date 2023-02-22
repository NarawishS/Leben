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
            ApplyJob("bank");
        }
        
        public void ApplyCasino()
        {
            ApplyJob("casino");
        }
        
        public void ApplyGym()
        {
            ApplyJob("gym");
        }
        
        public void ApplyFastFood()
        {
            ApplyJob("fastfood");
        }
        
        public void ApplyHospital()
        {
            ApplyJob("hospital");
        }
        
        public void ApplyMall()
        {
            ApplyJob("mall");
        }
        
        public void ApplyMarket()
        {
            ApplyJob("market");
        }
        
        public void ApplyPetShop()
        {
            ApplyJob("petshop");
        }
        
        public void ApplyUniversity()
        {
            ApplyJob("university");
        }
        
        public void ApplyVehicle()
        {
            ApplyJob("vehicle");
        }

        private void ApplyJob(string jobName)
        {
            Player player;

            if (GameManager.Instance.state == GameState.P1Turn)
            {
                player = GameManager.Instance.player1;
            }
            else
            {
                player = GameManager.Instance.player2;
            }

            player.SetJob(jobName);

            Debug.Log($"{player.name}: apply job for  {jobName}");

            timer.DecreaseTime(2);
        }
    }
}