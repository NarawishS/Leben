using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CreatePlayer : MonoBehaviour
{
    private BasePlayerStat newPlayer;
    public Text healthText;
    public Text wealthText;
    public Text educationText;
    public Text relaxText;
    public Text workHoursText;
    private int pointsToSpend = 20;

    void Start()
    {
        newPlayer = new BasePlayerStat();
        newPlayer.PlayerStat = new BaseStat();
        newPlayer.Health = newPlayer.PlayerStat.Health;
        newPlayer.Wealth = newPlayer.PlayerStat.Wealth;
        newPlayer.Education = newPlayer.PlayerStat.Education;
        newPlayer.Relax = newPlayer.PlayerStat.Relax;
        newPlayer.WorkHours = newPlayer.PlayerStat.WorkHours;
    }

    void UpdateUI()
    {
        healthText.text = newPlayer.Health.ToString();
        wealthText.text = newPlayer.Wealth.ToString();
        educationText.text = newPlayer.Education.ToString();
        relaxText.text = newPlayer.Relax.ToString();
        workHoursText.text = newPlayer.WorkHours.ToString();
    }

    public void SetHealth(int amount)
    {
        if (newPlayer.PlayerStat != null)
        {
            if (amount > 0 && pointsToSpend > 0)
            {
                newPlayer.Health += amount;
                pointsToSpend -= 1;
                UpdateUI();
            }
            else if (amount < 0 && newPlayer.Health > newPlayer.PlayerStat.Health)
            {
                
            }
        }
    }
}