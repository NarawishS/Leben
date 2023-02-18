using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Script.Locations
{
    public class JobOffice : MonoBehaviour
    {
        public Timer timer;

        public void ApplyFastFood()
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

            player.SetJob("fastfood");
            
            Debug.Log($"{player.name}: apply job for fastfood shop");
            timer.DecreaseTime(2);
        }

        public void ApplyJobOffice()
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

            player.SetJob("jobOffice");
            
            Debug.Log($"{player.name}: apply job for jobOffice");
            timer.DecreaseTime(2);
        }
        

        public void Work()
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

            if (player.GetJob() == "jobOffice")
            {
                Debug.Log($"{player.name}: work at jobOffice");

                player.SetWealth(50);
                player.SetWorkExp(10);

                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log($"{player.name}: You did not apply for jobOffice");
            }
        }
    }
}